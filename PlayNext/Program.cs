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

var games = await igdb.UploadGames(Urls.MaxLimit, 0);


#region Steam

/*var steamApi = new SteamApi(configuration["steamApiKey"]);*/

#endregion



