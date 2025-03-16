using Polly;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;
using PlayNextServer.DTOs;
using PlayNextServer.Models;

namespace PlayNextServer.Api;

public class SteamApi(string apiKey)
{
    private static readonly HttpClient Client = new HttpClient();
    
    private static readonly IAsyncPolicy<HttpResponseMessage> retryPolicy = Policy
        .HandleResult<HttpResponseMessage>(r => r.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
        .WaitAndRetryAsync(
            100, // Max tries
            attempt => TimeSpan.FromSeconds(15) //Delay
        );

    public async Task<IList<App>> GetAllApps()
    {
        var url = Urls.SteamAllApps + $"&key={apiKey}";
        IList<App> apps = new List<App>();
        using (HttpClient client = new HttpClient())
        {
            while (true)
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var responseDataA = JsonSerializer.Deserialize<GetAllResponseA>(json);
                var responseData = responseDataA.Response;
                foreach (var app in responseData.Apps)
                {
                    apps.Add(app);
                }

                if (!responseData.IsMoreResults)
                {
                    break;
                }

                //Adding new last_appid for next request 
                Uri uri = new Uri(url);
                var query = HttpUtility.ParseQueryString(uri.Query);
                query["last_appid"] = responseData.LastId.ToString();
                url = uri.GetLeftPart(UriPartial.Path) + "?" + query;
            }
        }

        return apps;
    }

    /*public async Task<Game?> GetAppDetail(GameInfo gameInfo)
    {
        var url = Urls.appDetail;
        url += $"?appids={gameInfo.AppId}";
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(response.ToString() + "\n" + e);
                throw;
            }

            var json = await response.Content.ReadAsStringAsync();
            if (json == "null")
            {
                return null;
            }
            var games = JsonSerializer.Deserialize<Dictionary<int, GameDetailResponse>>(json);
            if (!games[gameInfo.AppId].IsSuccess)
            {
                return null;
            }
            var game = games[gameInfo.AppId].Data;
            return game;
        }
    }*/

    /*public async Task<Game?> GetAppDetail(int id)
    {
        var url = Urls.SteamAppDetail;
        url += $"?appids={id}";
        var response = await retryPolicy.ExecuteAsync(async () =>
        {
            var result = await Client.GetAsync(url);
            if (result.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                Console.WriteLine("API вернуло ошибку 429, ожидание...");
            }
            return result;
        });
        
        try
        {
            
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Console.WriteLine(response.ToString() + "\n" + e);
            throw;
        }

        var json = await response.Content.ReadAsStringAsync();
        if (json == "null")
        {
            return null;
        }

        json = CleanApiResponse(json);
        var games = JsonSerializer.Deserialize<Dictionary<int, GameDetailResponse>>(json);
        if (!games[id].IsSuccess)
        {
            return null;
        }

        var game = games[id].Data;
        return new Game()
        {
            
        };
    }*/
    public static string CleanApiResponse(string input)
    {
        /*// Удаление HTML тегов
        string noHtml = Regex.Replace(input, "<.*?>", string.Empty);*/
    
        // Замена символов новой строки и возврата каретки на пробел
        string noNewlines = input.Replace("\n", " ").Replace("\r", " ");
    
        // Удаление лишних пробелов
        string cleaned = Regex.Replace(noNewlines, @"\s+", " ").Trim();
    
        return cleaned;
    }
}