using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlayNextServer.Api;
using PlayNextServer.Models;

namespace PlayNextServer.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IgdbApi _igdb;
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public TestController(IgdbApi igdb, IConfiguration configuration, AppDbContext context)
    {
        _igdb = igdb;
        _configuration = configuration;
        _context = context;
    }

    [HttpGet("Upload")]
	public async Task Upload()
	{
		await _igdb.Authorize(_configuration["igdbClientId"], _configuration["igdbClientSecret"]);
        int offset = 250000;
		while(true)
        {
            var collections = await _igdb.UploadAll<ReleaseDate>(Urls.GetReleaseDates, Urls.MaxLimit, offset, 400);

            if (collections is null || collections.Count == 0)
            {
                break;
            }

            foreach (var entity in collections)
            {
                /*if (entity.GameId.HasValue && !existingGameIds.Contains(entity.GameId.Value))
                {
                    entity.GameId = null; // Убираем некорректный CoverId сразу
                }*/

                var find = await _context.ReleaseDates.AsNoTracking().FirstOrDefaultAsync(c => c.Id == entity.Id);
                if (find is null)
                {
                    await _context.ReleaseDates.AddAsync(entity);
                }
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

                Console.WriteLine(Urls.MaxLimit + " обьектов сохранено. " + offset);
                offset += collections.Count;
        }
	}
}
