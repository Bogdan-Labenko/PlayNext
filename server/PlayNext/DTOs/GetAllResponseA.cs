using System.Text.Json.Serialization;

namespace PlayNextServer.DTOs;

public class GetAllResponseA
{
    [JsonPropertyName("response")]
    public GetAllResponse Response { get; set; }
}