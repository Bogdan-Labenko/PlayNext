using System.Text.Json;
using PlayNextServer.Models;
using PlayNextServer.Services.Converters;

namespace PlayNextServer.Api;

public class IgdbApi
{
    private readonly HttpClient _client = new HttpClient();

    public async Task Authorize(string clientId, string userSecret)
    {
        var request = string.Format(Urls.GetAccessToken, clientId, userSecret);
        var content = new StringContent("");
        var response = await _client.PostAsync(request, content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var jsonDocument = JsonDocument.Parse(json);
        string accessToken = jsonDocument.RootElement.GetProperty("access_token").GetString();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        _client.DefaultRequestHeaders.Add("Client-Id", clientId);
    }

    public async Task<IList<Game>?> UploadGames(int limit, int offset)
    {
        string request = Urls.GetGames;
        var content = new StringContent($"fields *;sort id asc; limit {limit};offset {offset};");
        var response = await _client.PostAsync(request, content);
        
        var json = await response.Content.ReadAsStringAsync();
        var games = JsonSerializer.Deserialize<IList<Game>>(json, JsonSettings.Options);
        return games;
    }
    
    public async Task<IList<AgeRating>?> UploadAgeRatings(int limit, int offset, int delay)
    {
        string request = Urls.GetAgeRatings;
        var content = new StringContent($"fields *;sort id asc; limit {limit};offset {offset};");
        var response = await _client.PostAsync(request, content);

        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        if (json is "null" or "[]")
        {
            return null;
        }
        Thread.Sleep(delay);
        
        var ratings = JsonSerializer.Deserialize<IList<AgeRating>>(json, JsonSettings.Options);
        return ratings;
    }
    
    public async Task<IList<Collection>?> UploadCollections(int limit, int offset, int delay)
    {
        string request = Urls.GetCollections;
        var content = new StringContent($"fields *;sort id asc; limit {limit};offset {offset};");
        var response = await _client.PostAsync(request, content);

        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        if (json is "null" or "[]")
        {
            return null;
        }
        Thread.Sleep(delay);
        
        var collections = JsonSerializer.Deserialize<IList<Collection>>(json, JsonSettings.Options);
        return collections;
    }
    
    public async Task<IList<CollectionType>?> UploadCollectionTypes(int limit, int offset, int delay)
    {
        string request = Urls.GetCollectionTypes;
        var content = new StringContent($"fields *;sort id asc; limit {limit};offset {offset};");
        var response = await _client.PostAsync(request, content);

        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        if (json is "null" or "[]")
        {
            return null;
        }
        Thread.Sleep(delay);
        
        var collections = JsonSerializer.Deserialize<IList<CollectionType>>(json, JsonSettings.Options);
        return collections;
    }
    
    public async Task<IList<T>?> UploadAll<T>(string? url, int limit, int offset, int delay)
    {
        string request = url;
        var content = new StringContent($"fields *;sort id asc; limit {limit};offset {offset};");
        var response = await _client.PostAsync(request, content);

        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        if (json is "null" or "[]")
        {
            return null;
        }
        Thread.Sleep(delay);
        
        var collection = JsonSerializer.Deserialize<IList<T>>(json, JsonSettings.Options);
        return collection;
    }
}