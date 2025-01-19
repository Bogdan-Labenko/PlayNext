using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SteamParse.Models;

public class Metacritic
{
    public int Id { get; set; }
    [JsonPropertyName("score")]
    public int Score { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
