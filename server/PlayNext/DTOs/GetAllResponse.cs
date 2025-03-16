using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs;

public class GetAllResponse
{
    [JsonPropertyName("apps")]
    public IList<App> Apps { get; set; }
    [JsonPropertyName("have_more_results")]
    public bool IsMoreResults { get; set; }
    [JsonPropertyName("last_appid")]
    public int LastId { get; set; }
}