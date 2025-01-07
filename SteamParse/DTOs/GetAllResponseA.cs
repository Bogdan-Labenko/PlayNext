using System.Text.Json.Serialization;

namespace SteamParse.DTOs;

public class GetAllResponseA
{
    [JsonPropertyName("response")]
    public GetAllResponse Response { get; set; }
}