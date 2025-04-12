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
        string _name = name;
        string slug;
        _name = _name.ToLower().Trim();
        slug = Regex.Replace(_name, @"\s+", "-"); // Заменить пробелы на '-'
        //_name = Regex.Replace(_name, @"[^a-z0-9\-]", "");

        var timer = new Stopwatch();
        
        var maxRatings = context.Games
            .Max(g => g.AggregatedRatingCount);
        
        var query = context.Games.
            Include(g => g.AlternativeNames)
            .Include(g => g.GameType)
            .Where(g =>
                g.GameTypeId == 0 && g.AggregatedRatingCount > 0 &&
                (g.Slug.Contains(slug) || g.AlternativeNames.Any(a => a.Name.ToLower().Contains(_name)))
            )
            .OrderByDescending(g => g.Slug.Equals(_name))
            .ThenByDescending(g => g.Slug.StartsWith(_name))
            .ThenByDescending(g => g.AggregatedRating * (g.AggregatedRatingCount / (double)maxRatings))
            .Take(3);
        
        timer.Start();
        query = _includeService.ApplyIncludes(query, resolverContext);
        timer.Stop();
        Console.WriteLine("Milliseconds: " + timer.Elapsed.TotalMilliseconds);

        return query;
    }
}