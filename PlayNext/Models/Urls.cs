namespace PlayNextServer.Models;

public static class Urls
{
    //Steam
    public const string SteamAllApps = "https://api.steampowered.com/IStoreService/GetAppList/v1/?include_games=true&include_dlc=false&include_software=false&include_videos=false&include_hardware=false&max_results=50000";
    public const string SteamAppDetail = "https://store.steampowered.com/api/appdetails";
    
    //IGDB
    public const int MaxLimit = 500;
    public const string GetAccessToken = "https://id.twitch.tv/oauth2/token?client_id={0}&client_secret={1}&grant_type=client_credentials";
    public const string GetGames = "https://api.igdb.com/v4/games";
    public const string GetAgeRatings = "https://api.igdb.com/v4/age_ratings";
    public const string GetCollections = "https://api.igdb.com/v4/collections";
    public const string GetCollectionTypes = "https://api.igdb.com/v4/collection_types";
}