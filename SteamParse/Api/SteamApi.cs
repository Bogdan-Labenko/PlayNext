using System.Text.Json;
using System.Web;
using SteamParse.DTOs;
using SteamParse.Models;

namespace SteamParse.Api;

public class SteamApi(string apiKey)
{
    public async Task<IList<App>> GetAllApps()
    {
        var url = Urls.allApps + $"&key={apiKey}";
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

    /*public string GetAppDetail()
    {
    }*/
}