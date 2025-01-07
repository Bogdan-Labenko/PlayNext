using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SteamParse;
using SteamParse.Models;
using Microsoft.Extensions.Configuration;
using SteamParse.Api;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

AppDbContext context = new AppDbContext();

var steamApi = new SteamApi(configuration["apiKey"]);

var apps = await steamApi.GetAllApps();


foreach (var game in apps)
{
    await context.GamesInfo.AddAsync(new GameInfo()
    {
        Name = game.Name,
        AppId = game.AppId,
        LastModified = game.LastModified,
        PriceChangeNumber = game.PriceChangeNumber
    });
}

await context.SaveChangesAsync();



