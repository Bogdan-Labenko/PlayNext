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
    public const string GetArtworks = "https://api.igdb.com/v4/artworks";
    public const string GetCovers = "https://api.igdb.com/v4/covers";
    public const string GetCollections = "https://api.igdb.com/v4/collections";
    public const string GetCollectionTypes = "https://api.igdb.com/v4/collection_types";
    public const string GetFranchises = "https://api.igdb.com/v4/franchises";
    public const string GetGameEngineLogos = "https://api.igdb.com/v4/game_engine_logos";
    public const string GetGameEngines = "https://api.igdb.com/v4/game_engines";
    public const string GetGameLocalizations = "https://api.igdb.com/v4/game_localizations";
    public const string GetRegions = "https://api.igdb.com/v4/regions";
    public const string GetGameVideos = "https://api.igdb.com/v4/game_videos";
    public const string GetGenres = "https://api.igdb.com/v4/genres";
    public const string GetInvolvedCompany = "https://api.igdb.com/v4/involved_companies";
    public const string GetKeywords = "https://api.igdb.com/v4/keywords";
    public const string GetLanguageSupports = "https://api.igdb.com/v4/language_supports";
    public const string GetLanguageSupportTypes = "https://api.igdb.com/v4/language_support_types";
    public const string GetLanguages = "https://api.igdb.com/v4/languages";
    public const string GetMultiplayerModes = "https://api.igdb.com/v4/multiplayer_modes";
    public const string GetPlatforms = "https://api.igdb.com/v4/platforms";
    public const string GetPlatformFamilies = "https://api.igdb.com/v4/platform_families";
    public const string GetPlatformLogos = "https://api.igdb.com/v4/platform_logos";
    public const string GetPlayerPerspectives = "https://api.igdb.com/v4/player_perspectives";
    public const string GetPopularityPrimitives = "https://api.igdb.com/v4/popularity_primitives";
    public const string GetPopularityTypes = "https://api.igdb.com/v4/popularity_types"; 
    public const string GetReleaseDateStatuses = "https://api.igdb.com/v4/release_date_statuses";
    public const string GetReleaseDates = "https://api.igdb.com/v4/release_dates";
    public const string GetScreenshots = "https://api.igdb.com/v4/screenshots";
    public const string GetThemes = "https://api.igdb.com/v4/themes";
    public const string GetWebsites = "https://api.igdb.com/v4/websites";
}