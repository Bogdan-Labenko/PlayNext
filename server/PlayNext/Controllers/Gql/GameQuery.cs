using System.Diagnostics;
using System.Text.RegularExpressions;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using PlayNextServer.Models.Database_v1;
using PlayNextServer.Services;

namespace PlayNextServer.Controllers.Gql;

public class GameQuery
{
    private readonly GraphQLIncludeService _includeService;
    public GameQuery(GraphQLIncludeService includeService)
    {
        _includeService = includeService;
    }
    
    public IQueryable<Game> GetGames(
        [Service] AppDbContext context,
        int limit = 10,
        int offset = 0
    )
    {
        return context.Games
            .OrderBy(g => g.Id)
            .Skip(offset)
            .Take(limit);
    }

    public IQueryable<Game> GetThreeGamesByName(
        [Service] AppDbContext context,
        IResolverContext resolverContext,
        string name
    )
    {
        var (slug, _name) = Normalize(name);
        
        var maxRatings = context.Games
            .AsNoTracking()
            .Max(g => g.AggregatedRatingCount);
        
        var query = context.Games
            .AsNoTracking()
            .Where(g =>
                (g.GameTypeId == 0 || g.GameTypeId == 8 || g.GameTypeId == 8) && g.AggregatedRatingCount > 0 &&
                (g.Slug.Contains(slug) || g.AlternativeNames.Any(a => a.Name.ToLower().Contains(_name)))
            )
            .OrderByDescending(g => g.Slug.Equals(_name))
            .ThenByDescending(g => g.Slug.StartsWith(_name))
            .ThenByDescending(g => g.AggregatedRating * (g.AggregatedRatingCount / (double)maxRatings))
            //.ThenByDescending(g => g.FirstReleaseDate)
            .Take(3);


        query = _includeService.ApplyIncludes(query, resolverContext);

        return query;
    }

    public IQueryable<Game> GetGamesByName(
        [Service] AppDbContext context,
        IResolverContext resolverContext,
        string name,
        int limit = 24,
        int page = 1
    )
    {
        var (slug, _name) = Normalize(name);
        int skip = (page - 1) * limit;
        
        var maxRatings = context.Games
            .AsNoTracking()
            .Max(g => g.AggregatedRatingCount);
        
        var query = context.Games
            .AsNoTracking()
            .Where(g =>
                (g.GameTypeId == 0 || g.GameTypeId == 8 || g.GameTypeId == 9 || g.GameTypeId == 11) &&
                (g.Slug.Contains(slug) || g.AlternativeNames.Any(a => a.Name.ToLower().Contains(_name)))
            )
            .OrderByDescending(g => g.Slug.Equals(_name))
            .ThenByDescending(g => g.Slug.StartsWith(_name))
            .ThenByDescending(g => g.AggregatedRating * (g.AggregatedRatingCount / (double)maxRatings))
            .Skip(skip)
            .Take(limit);

        return _includeService.ApplyIncludes(query, resolverContext);
    }

    private (string slug, string name) Normalize(string name)
    {
        string slug;
        name = name.ToLower().Trim();
        slug = Regex.Replace(name, @"\s+", "-"); // Заменить пробелы на '-'

        return (slug, name);
    }
}