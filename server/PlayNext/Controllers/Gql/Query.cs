using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using PlayNextServer.Models;

namespace PlayNextServer.Controllers.Gql;

public class Query
{
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
        string name,
        int limit = 10
    )
    {
        string _name = name;
        _name = _name.ToLower().Trim(); // Привести к нижнему регистру
        _name = Regex.Replace(_name, @"\s+", "-"); // Заменить пробелы на '-'
         _name = Regex.Replace(_name, @"[^a-z0-9\-]", "");
        return context.Games
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
            .Take(limit);
    }
}