using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlayNextServer.Api;
using PlayNextServer.DTOs.Data;
using PlayNextServer.Extensions;
using PlayNextServer.Models.Database_v1;

namespace PlayNextServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FetchingController : ControllerBase
{
    private readonly IgdbApi _igdb;
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public FetchingController(IgdbApi igdb, IConfiguration configuration, AppDbContext context)
    {
        _igdb = igdb;
        _configuration = configuration;
        _context = context;
        _igdb.Authorize(_configuration["igdbClientId"], _configuration["igdbClientSecret"])
            .GetAwaiter()
            .GetResult();
    }

    [HttpGet("upload_1")]
	public async Task Upload()
	{
        int offset = 0;
		while(true)
        {
            var collectionDto = await _igdb.UploadAll<GameDto>(Urls.GetGames, Urls.MaxLimit, offset, 400);

            if (collectionDto is null || collectionDto.Count == 0)
            {
                break;
            }

            /*var collection = collectionDto.ToModel(c => new PlayerPerspective
            {
                Id = c.Id,
                Checksum = c.Checksum,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                Name = c.Name,
                Slug = c.Slug,
            });*/
            
            foreach (var entity in collectionDto)
            {
                /*if (entity.GameId.HasValue && !existingGameIds.Contains(entity.GameId.Value))
                {
                    entity.GameId = null; // Убираем некорректный CoverId сразу
                }*/

                var find = await _context.PlayerPerspectives
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == entity.Id);
                if (find is not null)
                {
                    //await _context.PlayerPerspectives.AddAsync(entity);
                    continue;
                }
                
                
                
                /*var company = new Company
                {
                    Id = entity.Id,
                    Checksum = entity.Checksum,
                    Name = entity.Name,
                    CreatedAt = entity.CreatedAt,
                    UpdatedAt = entity.UpdatedAt,
                    Slug = entity.Slug,
                    Description = entity.Description,
                    LogoId = entity.LogoId,
                    CountryCode = entity.CountryCode,
                    StartDate = entity.StartDate,
                    ParentCompanyId = entity.ParentCompanyId
                };*/
                /*
                    find.Id = entity.Id;
                    find.Checksum = entity.Checksum;
                    find.CreatedAt = entity.CreatedAt;
                    find.UpdatedAt = entity.UpdatedAt;
                    find.Slug = entity.Slug;
                    find.Name = entity.Name;
                    find.Description = entity.Description;
                    find.LogoId = entity.LogoId;
                 */
            }
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            /*while (true) // Цикл, пока не удастся сохранить изменения
            {
                try
                {

                }
                /*catch (DbUpdateException e) when (e.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
                {
                    Match match = Regex.Match(pgEx.Detail, @"\((\d+)\)");

                    if (match.Success)
                    {
                        int coverId = int.Parse(match.Groups[1].Value);
                        var game = collections.FirstOrDefault(g => g.CoverId == coverId);
                        game.CoverId = null;
                        await context.SaveChangesAsync();
                        context.ChangeTracker.Clear();
                        Console.WriteLine(game.Id + " game set cover id 0.");
                    }
                }#1#
                catch (DbUpdateException e)
                {
                     Находим PostgresException в цепочке исключений
                    var pgEx = e.GetBaseException() as PostgresException;

                    if (pgEx != null && pgEx.SqlState == "23503")
                    {
                        Match match = Regex.Match(pgEx.Detail, @"\((\d+)\)");

                        if (match.Success)
                        {
                            int coverId = int.Parse(match.Groups[1].Value);
                            var game = collections.FirstOrDefault(g => g.CoverId == coverId);

                            if (game != null)
                            {
                                game.CoverId = null;
                                context.Update(game);
                                Console.WriteLine($"{game.Id} game set cover id to null.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка базы данных: {e.Message}");
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                    throw;
                }*/

                Console.WriteLine("1 | " + Urls.MaxLimit + " обьектов сохранено. " + offset);
                offset += collectionDto.Count;
        }
	}
    
    [HttpGet("upload_2")]
	public async Task UploadA()
	{
        int offset = 0;
		while(true)
        {
            var collectionDto = await _igdb.UploadAll<GameDto>(Urls.GetGames, Urls.MaxLimit, offset, 0);

            if (collectionDto is null || collectionDto.Count == 0)
            {
                break;
            }

            if (offset > 0)
            {
                break;
            }
            
            /*var collection = collectionDto.ToModel(a => new Game
            {
                CoverId = a.CoverId,
                Name = a.Name,
                Checksum = a.Checksum,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                /*Id = a.Id,
                Checksum = a.Checksum,
                Animated = a.Animated,
                Height = a.Height,
                Width = a.Width,
                AlphaChannel = a.AlphaChannel,
                ImageId = a.ImageId,#1#
            });*/
            
            foreach (var entity in collectionDto)
            {
                /*if (entity.GameId.HasValue && !existingGameIds.Contains(entity.GameId.Value))
                {
                    entity.GameId = null; // Убираем некорректный CoverId сразу
                }*/

                var find = await _context.Games.AsNoTracking().FirstOrDefaultAsync(c => c.Id == entity.Id);
                if (find is not null)
                {
                    continue;
                }

                var game = new Game()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Checksum = entity.Checksum,
                    CreatedAt = entity.CreatedAt,
                    UpdatedAt = entity.UpdatedAt,
                    Slug = entity.Slug,
                    Storyline = entity.Storyline,
                    Summary = entity.Summary,
                    Tags = entity.Tags,
                    AggregatedRating = entity.AggregatedRating,
                    AggregatedRatingCount = entity.AggregatedRatingCount,
                    GameStatusId = entity.GameStatusId,
                    GameTypeId = entity.GameTypeId,
                    FirstReleaseDate = entity.FirstReleaseDate,
                    GameStatusEnum = entity.GameStatusEnum
                };

                //Genre
                if (entity.GenresId is not null && entity.GenresId.Count > 0)
                {
                    var genres = await _context.Genres
                        .Where(g => entity.GenresId.Contains(g.Id))
                        .ToListAsync();
                    if (genres.Count > 0)
                    {
                        game.Genres = genres;
                    }
                }
                
                //Cover
                var cover = await _context.Covers
                    .FirstOrDefaultAsync(g => entity.CoverId == g.Id);
                if (cover is not null)
                {
                    game.Cover = cover;
                }
                //Alternative names
                if (entity.AlternativeNamesId is not null && entity.AlternativeNamesId.Count > 0)
                {
                    var altNames = await _context.AlternativeNames
                        .Where(g => entity.AlternativeNamesId.Contains(g.Id))
                        .ToListAsync();
                    if (altNames.Count > 0)
                    {
                        game.AlternativeNames = altNames;
                    }
                }
                
                //Artworks
                if (entity.ArtworksId is not null && entity.ArtworksId.Count > 0)
                {
                    var artworks = await _context.Artworks
                        .Where(g => entity.ArtworksId.Contains(g.Id))
                        .ToListAsync();
                    if (artworks.Count > 0)
                    {
                        game.Artworks = artworks;
                    }
                }
                
                //Dlcs
                /*var dlcs = await _context.Games
                    .Where(g => entity.DlcsId.Contains(g.Id))
                    .ToListAsync();
                if (altNames is not null)
                {
                    game.Dlcs = dlcs;
                }*/
                
                //Franchises
                if (entity.GameFranchisesId is not null && entity.GameFranchisesId.Count > 0)
                {
                    var f = await _context.Franchises
                        .Where(g => entity.GameFranchisesId.Contains(g.Id))
                        .ToListAsync();
                    if (f.Count > 0)
                    {
                        game.Franchises = f;
                    }
                }
                
                //GameEngines
                if (entity.GameEnginesId is not null && entity.GameEnginesId.Count > 0)
                {
                    var ge = await _context.GameEngines
                        .Where(g => entity.GameEnginesId.Contains(g.Id))
                        .ToListAsync();
                    if (ge.Count > 0)
                    {
                        game.GameEngines = ge;
                    }
                }
                //GameModes
                if (entity.GameModesId is not null && entity.GameModesId.Count > 0)
                {
                    var gm = await _context.GameModes
                        .Where(g => entity.GameModesId.Contains(g.Id))
                        .ToListAsync();
                    if (gm.Count > 0)
                    {
                        game.GameModes = gm;
                    }
                }
                //Keywords
                if (entity.KeywordsId is not null && entity.KeywordsId.Count > 0)
                {
                    var keywords = await _context.Keywords
                        .Where(g => entity.KeywordsId.Contains(g.Id))
                        .ToListAsync();
                    if (keywords.Count > 0)
                    {
                        game.Keywords = keywords;
                    }
                }
                //Keywords
                if (entity.LanguageSupportsId is not null && entity.LanguageSupportsId.Count > 0)
                {
                    var ls = await _context.LanguageSupports
                        .Where(g => entity.LanguageSupportsId.Contains(g.Id))
                        .ToListAsync();
                    
                    if (ls.Count > 0)
                    {
                        game.LanguageSupports = ls;
                    }
                }
                //MultiplayerModes
                if (entity.MultiplayerModesId is not null && entity.MultiplayerModesId.Count > 0)
                {
                    var mm = await _context.MultiplayerModes
                        .Where(g => entity.MultiplayerModesId.Contains(g.Id))
                        .ToListAsync();
                    
                    if (mm.Count > 0)
                    {
                        game.MultiplayerModes = mm;
                    }
                }
                //Platforms
                if (entity.PlatformsId is not null && entity.PlatformsId.Count > 0)
                {
                    var platforms = await _context.Platforms
                        .Where(g => entity.PlatformsId.Contains(g.Id))
                        .ToListAsync();
                    
                    if (platforms.Count > 0)
                    {
                        game.Platforms = platforms;
                    }
                }
                //PlayerPerspectives
                if (entity.PlayerPerspectivesId is not null && entity.PlayerPerspectivesId.Count > 0)
                {
                    var pp = await _context.PlayerPerspectives
                        .Where(g => entity.PlayerPerspectivesId.Contains(g.Id))
                        .ToListAsync();
                    
                    if (pp.Count > 0)
                    {
                        game.PlayerPerspectives = pp;
                    }
                }
                //Screenshots
                if (entity.ScreenshotsId is not null && entity.ScreenshotsId.Count > 0)
                {
                    var screenshots = await _context.Screenshots
                        .Where(g => entity.ScreenshotsId.Contains(g.Id))
                        .ToListAsync();
                    
                    if (screenshots.Count > 0)
                    {
                        game.Screenshots = screenshots;
                    }
                }
                //Themes
                if (entity.ThemesId is not null && entity.ThemesId.Count > 0)
                {
                    var themes = await _context.Themes
                        .Where(g => entity.ThemesId.Contains(g.Id))
                        .ToListAsync();
                    
                    if (themes.Count > 0)
                    {
                        game.Themes = themes;
                    }
                }
                //Videos
                if (entity.VideosId is not null && entity.VideosId.Count > 0)
                {
                    var videos = await _context.GameVideos
                        .Where(g => entity.VideosId.Contains(g.Id))
                        .ToListAsync();
                    
                    if (videos.Count > 0)
                    {
                        game.Videos = videos;
                    }
                }
                
                await _context.Games.AddAsync(game);

            }
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            /*while (true) // Цикл, пока не удастся сохранить изменения
            {
                try
                {

                }
                /*catch (DbUpdateException e) when (e.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
                {
                    Match match = Regex.Match(pgEx.Detail, @"\((\d+)\)");

                    if (match.Success)
                    {
                        int coverId = int.Parse(match.Groups[1].Value);
                        var game = collections.FirstOrDefault(g => g.CoverId == coverId);
                        game.CoverId = null;
                        await context.SaveChangesAsync();
                        context.ChangeTracker.Clear();
                        Console.WriteLine(game.Id + " game set cover id 0.");
                    }
                }#1#
                catch (DbUpdateException e)
                {
                     Находим PostgresException в цепочке исключений
                    var pgEx = e.GetBaseException() as PostgresException;

                    if (pgEx != null && pgEx.SqlState == "23503")
                    {
                        Match match = Regex.Match(pgEx.Detail, @"\((\d+)\)");

                        if (match.Success)
                        {
                            int coverId = int.Parse(match.Groups[1].Value);
                            var game = collections.FirstOrDefault(g => g.CoverId == coverId);

                            if (game != null)
                            {
                                game.CoverId = null;
                                context.Update(game);
                                Console.WriteLine($"{game.Id} game set cover id to null.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка базы данных: {e.Message}");
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                    throw;
                }*/

                Console.WriteLine("2 | " + Urls.MaxLimit + " обьектов сохранено. " + offset);
                offset += collectionDto.Count;
        }
	}
    
    [Route("test")]
    public async Task<IActionResult> Games()
    {
        /*string a = "red";
        var games = await _context.Games.Include(g => g.Platforms).Where(g => g.Slug.Contains(a)).Take(10).ToListAsync();
        var json = JsonSerializer.Serialize(games);
        return Ok(json);*/
        var game = _context.Games.Include(e => e.Genres)
            .FirstOrDefault();
        return Ok(game);
        
        //Продолжить скачивание всего что нужно и потом скачивание игры со всеми связями
    }
}
