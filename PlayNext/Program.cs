using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SteamParse;
using Microsoft.Extensions.Configuration;
using SteamParse.Api;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

AppDbContext context = new AppDbContext();

var steamApi = new SteamApi(configuration["apiKey"]);

/*var apps = await steamApi.GetAllApps();


foreach (var game in apps)
{
    await context.GamesInfo.AddAsync(new GameInfo()
    {
        Name = game.Name,
        AppId = game.AppId,
        LastModified = game.LastModified,
        PriceChangeNumber = game.PriceChangeNumber
    });
}*/

var gamesInfo = await context.GamesInfo.Where(g => g.AppId > 25520).ToListAsync();

int i = 0;
int lastId;
Stopwatch stopWatch = new Stopwatch();

foreach (var info in gamesInfo)
{
    if (i > 10)
    {
        //await context.SaveChangesAsync();
        i = 0;
    }
    stopWatch.Start();
    var temp = await steamApi.GetAppDetail(info.AppId);
    stopWatch.Stop();
    i++;
    if (temp is null)
    {
        continue;
    }

    var isExist = await context.Games.FirstOrDefaultAsync(g => g.SteamId == temp.SteamId);
    if (isExist is not null)
    {
        isExist.Name = temp.Name;
        isExist.Categories = temp.Categories;
        isExist.Genres = temp.Genres;
        isExist.Developers = temp.Developers;
        isExist.Metacritic = temp.Metacritic;
        isExist.Publishers = temp.Publishers;
        isExist.Screenshots = temp.Screenshots;
        isExist.Website = temp.Website;
        isExist.CapsuleImage = temp.CapsuleImage;
        isExist.HeaderImage = temp.HeaderImage;
        isExist.ControllerSupport = temp.ControllerSupport;
        isExist.IsFree = temp.IsFree;
        isExist.LegalNotice = temp.LegalNotice;
        isExist.ReleaseDate = temp.ReleaseDate;
        isExist.RequiredAge = temp.RequiredAge;
        isExist.ShortDescription = temp.ShortDescription;
        isExist.SupportedLanguages = temp.SupportedLanguages;
        isExist.CapsuleImageSmall = temp.CapsuleImageSmall;
        isExist.PcRequirements = temp.PcRequirements;
    }
    else
    {
        context.Games.Add(temp);
    }
    lastId = temp.SteamId;
    Console.WriteLine(temp.Name + " " + temp.SteamId + " Time: " + stopWatch.Elapsed.TotalMinutes);
    stopWatch.Reset();
} 

await context.SaveChangesAsync();



