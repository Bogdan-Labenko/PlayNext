using Microsoft.EntityFrameworkCore;
using PlayNextServer;
using Microsoft.Extensions.Configuration;
using PlayNextServer.Api;
using PlayNextServer.Models;


var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

AppDbContext context = new AppDbContext();

var igdb = new IgdbApi();
await igdb.Authorize(configuration["igdbClientId"], configuration["igdbClientSecret"]);

int offset = 0;

while(true)
{
    var collections = await igdb.UploadAll<AgeRating>(Urls.GetAgeRatings, Urls.MaxLimit, offset, 100);

    if (collections is null || collections.Count == 0)
    {
        break;
    }

    foreach (var collection in collections)
    {
        var find = await context.AgeRatings.FirstOrDefaultAsync(c => c.Id == collection.Id);
        if (find is null)
        {
            await context.AgeRatings.AddRangeAsync(collections);
        }
    }
    
    await context.SaveChangesAsync();
    Console.WriteLine(Urls.MaxLimit + " коллекций сохранено. " + offset);
    offset += collections.Count;
}



#region Steam

/*var steamApi = new SteamApi(configuration["steamApiKey"]);*/

#endregion



