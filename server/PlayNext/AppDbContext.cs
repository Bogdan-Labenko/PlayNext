using Microsoft.EntityFrameworkCore;
using Npgsql;
using PlayNextServer.Models;
using PlayNextServer.Models.Auth;

namespace PlayNextServer;

public class AppDbContext : DbContext
{
    public DbSet<AgeRating> AgeRatings { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<CollectionType> CollectionTypes { get; set; }
    public DbSet<Cover> Covers { get; set; }
    public DbSet<Franchise> Franchises { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameEngine> GameEngines { get; set; }
    public DbSet<GameEngineLogo> GameEngineLogos { get; set; }
    public DbSet<GameLocalization> GameLocalizations { get; set; }
    public DbSet<GameMode> GameModes { get; set; }
    public DbSet<GameVideo> GameVideos { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<InvolvedCompany> InvolvedCompanies { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageSupport> LanguageSupports { get; set; }
    public DbSet<LanguageSupportType> LanguageSupportTypes { get; set; }
    public DbSet<MultiplayerMode> MultiplayerModes { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<PlatformFamily> PlatformFamilies { get; set; }
    public DbSet<PlatformLogo> PlatformLogos { get; set; }
    public DbSet<PlayerPerspective> PlayerPerspectives { get; set; }
    public DbSet<PopularityPrimitive> PopularityPrimitives { get; set; }
    public DbSet<PopularityType> PopularityTypes { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<ReleaseDate> ReleaseDates { get; set; }
    public DbSet<ReleaseDateStatus> ReleaseDateStatuses { get; set; }
    public DbSet<Screenshot> Screenshots { get; set; }
    public DbSet<Theme> Themes { get; set; }
    public DbSet<Website> Websites { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(new NpgsqlConnection("Host=localhost;Port=5432;Database=next_play;Username=postgres;Password=user;Encoding=UTF8;Include Error Detail=true;"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Artwork>()
            .HasOne<Game>(a => a.Game)
            .WithMany(g => g.Artworks);*/

        /*modelBuilder.Entity<Game>()
            .HasOne<Cover>(g => g.Cover)
            .WithOne(c => c.Game)
            .HasForeignKey<Cover>(c => c.GameId);*/
        
        /*modelBuilder.Entity<Game>()
            .HasOne(g => g.Cover)
            .WithOne(c => c.Game)
            .HasForeignKey()
            .OnDelete(DeleteBehavior.Cascade);*/
    }
}