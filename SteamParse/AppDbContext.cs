using Microsoft.EntityFrameworkCore;
using Npgsql;
using SteamParse.Models;

namespace SteamParse;

class AppDbContext : DbContext
{
    public DbSet<GameInfo> GamesInfo { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Metacritic> Metacritics { get; set; }
    public DbSet<Screenshot> Screenshots { get; set; }
    public DbSet<ReleaseDate> ReleaseDates { get; set; }
    public DbSet<PcRequirements> PcRequirements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(new NpgsqlConnection("Host=localhost;Port=5432;Database=next_play;Username=postgres;Password=user;Encoding=UTF8;Include Error Detail=true;"));
    }
}