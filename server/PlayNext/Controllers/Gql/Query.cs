using System.Diagnostics;
using System.Text.RegularExpressions;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using PlayNextServer.Models;
using PlayNextServer.Services;
using Timer = System.Timers.Timer;

namespace PlayNextServer.Controllers.Gql;

public class Query
{
    private readonly GraphQLIncludeService _includeService;
    public Query(GraphQLIncludeService includeService)
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

    public IQueryable<Game> GetGamesByName(
        [Service] AppDbContext context,
        IResolverContext resolverContext,
        string name,
        int limit = 10,
        int offset = 0
    )
    {
        string _name = name;
        _name = _name.ToLower().Trim(); // Привести к нижнему регистру
        _name = Regex.Replace(_name, @"\s+", "-"); // Заменить пробелы на '-'
        _name = Regex.Replace(_name, @"[^a-z0-9\-]", "");

        var query = context.Games
            .Where(g =>
                g.Category == Category.MainGame &&
                g.Slug.Contains(_name) &&
                g.VersionParentId == 0
            );
        var timer = new Stopwatch();
        
        timer.Start();
        var tempQuery = _includeService.ApplyIncludes(query, resolverContext);
        timer.Stop();
        Console.WriteLine("Milliseconds: " + timer.Elapsed.TotalMilliseconds);
        query = tempQuery
            .OrderByDescending(g => g.Slug.Equals(_name))
            .ThenByDescending(g => g.Rating)
            .ThenByDescending(g => g.Slug.StartsWith(_name))
            .ThenByDescending(g => g.FirstReleaseDate);

        return query.Skip(offset).Take(limit);

        /*return context.Games
            .Include(g => g.ReleaseDates)
            .Include(g => g.Cover)
            .Where(g =>
                    g.Category == Category.MainGame
                    && g.Slug.Contains(_name)
                    && g.VersionParentId == 0
                ) // Фильтр по имени
            .OrderByDescending(g => g.Slug.Equals(_name)) // Полное совпадение выше
            .ThenByDescending(g => g.Rating) // Популярность
            .ThenByDescending(g => g.Slug.StartsWith(_name)) // Начинается с искомого - выше
            .ThenByDescending(g => g.ReleaseDates
                .OrderBy(rd => rd.Date)
                .Select(rd => rd.Date)
                .FirstOrDefault()) // Самая ранняя дата релиза
            .Skip(offset)
            .Take(limit);*/
    }
}