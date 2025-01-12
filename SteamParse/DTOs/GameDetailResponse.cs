using System.Text.Json.Serialization;

namespace SteamParse.DTOs;

public class GameDetailResponse
{
    [JsonPropertyName("success")]
    public bool IsSuccess { get; set; }
    [JsonPropertyName("data")]
    public Game Data { get; set; }
}