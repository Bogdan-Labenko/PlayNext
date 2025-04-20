using Microsoft.EntityFrameworkCore;
using Npgsql;
using PlayNextServer.DTOs.Data;
using PlayNextServer.Models;
using PlayNextServer.Models.Database_v1;
using PlayNextServer.Models.Auth;

namespace PlayNextServer;

public class AppDbContext : DbContext
{
    public DbSet<AlternativeName> AlternativeNames { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyLogo> CompanyLogos { get; set; }
    public DbSet<CompanyStatus> CompanyStatuses { get; set; }
    public DbSet<Cover> Covers { get; set; }
    public DbSet<Franchise> Franchises { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameEngine> GameEngines { get; set; }
    public DbSet<GameEngineLogo> GameEngineLogos { get; set; }
    public DbSet<GameMode> GameModes { get; set; }
    public DbSet<GameStatus> GameStatuses { get; set; }
    public DbSet<GameType> GameTypes { get; set; }
    public DbSet<GameVideo> GameVideos { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<InvolvedCompany> InvolvedCompanies { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageSupport> LanguageSupports { get; set; }
    public DbSet<LanguageSupportType> LanguageSupportTypes { get; set; }
    public DbSet<MultiplayerMode> MultiplayerModes { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<PlatformLogo> PlatformLogos { get; set; }
    public DbSet<PlatformType> PlatformTypes { get; set; }
    public DbSet<PlayerPerspective> PlayerPerspectives { get; set; }
    public DbSet<ReleaseDate> ReleaseDates { get; set; }
    public DbSet<ReleaseDateStatus> ReleaseDateStatuses { get; set; }
    public DbSet<Screenshot> Screenshots { get; set; }
    public DbSet<Theme> Themes { get; set; }
    
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
        
        ////////////////////////////////////////////
        // Связь Game -> GameFranchise
        /*modelBuilder.Entity<GameFranchise>()
            .HasKey(gf => new { gf.GameId, gf.FranchiseId });
        
        modelBuilder.Entity<GameFranchise>()
            .HasOne(gf => gf.Game)
            .WithMany(g => g.GameFranchises)
            .HasForeignKey(gf => gf.GameId);
        
        modelBuilder.Entity<GameFranchise>()
            .HasOne(gf => gf.Franchise)
            .WithMany(f => f.GameFranchises)
            .HasForeignKey(gf => gf.FranchiseId);*/
        
        ////////////////////////////////////////////
        // Связь Game -> GameEngines
        
        /*modelBuilder.Entity<GameGameEngines>()
            .HasKey(gf => new { gf.GameId, gf.GameEngineId });
        
        modelBuilder.Entity<GameGameEngines>()
            .HasOne(gg => gg.GameEngine)
            .WithMany(ge => ge.GameGameEngines)
            .HasForeignKey(gg => gg.GameEngineId);
        
        modelBuilder.Entity<GameGameEngines>()
            .HasOne(gg => gg.Game)
            .WithMany(ge => ge.GameGameEngines)
            .HasForeignKey(gg => gg.GameEngineId);*/

        ////////////////////////////////////////////
        // Связь Game -> GameMode
        /*modelBuilder.Entity<GameGameMode>()
            .HasKey(gf => new { gf.GameId, gf.GameModeId });
        
        modelBuilder.Entity<GameGameMode>()
            .HasOne(gg => gg.Game)
            .WithMany(ge => ge.GameGameModes)
            .HasForeignKey(gg => gg.GameId);
        
        modelBuilder.Entity<GameGameMode>()
            .HasOne(gg => gg.Game)
            .WithMany(ge => ge.GameGameModes)
            .HasForeignKey(gg => gg.GameId);*/

        ////////////////////////////////////////////
        // Связь Game -> Genres
        
        /*modelBuilder.Entity<Game>()
            .HasOne(g => g.ParentGame)
            .WithMany()
            .HasForeignKey(g => g.ParentGameId)
            .OnDelete(DeleteBehavior.Restrict);*/
        
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Cover)
            .WithOne(c => c.Game)
            .HasForeignKey<Game>(g => g.CoverId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Game>()
            .HasOne(g => g.BaseGame)
            .WithMany(g => g.Dlcs)
            .HasForeignKey(g => g.BaseGameId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Artwork>()
            .HasOne(a => a.Game)
            .WithMany(g => g.Artworks)
            .HasForeignKey(a => a.GameId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<AlternativeName>()
            .HasOne(a => a.Game)
            .WithMany(g => g.AlternativeNames)
            .HasForeignKey(a => a.GameId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<LanguageSupport>()
            .HasOne(a => a.Game)
            .WithMany(g => g.LanguageSupports)
            .HasForeignKey(a => a.GameId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Screenshot>()
            .HasOne(a => a.Game)
            .WithMany(g => g.Screenshots)
            .HasForeignKey(a => a.GameId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<GameVideo>()
            .HasOne(a => a.Game)
            .WithMany(g => g.Videos)
            .HasForeignKey(a => a.GameId)
            .OnDelete(DeleteBehavior.SetNull);

        /*modelBuilder.Entity<Game>()
            .HasMany(g => g.Genres)
            .WithMany(g => g.Games)
            .UsingEntity<Dictionary<string, object>>(
                "GameGenre", // имя промежуточной таблицы
                j => j
                    .HasOne<Genre>()
                    .WithMany()
                    .HasForeignKey("GenreId")
                    .OnDelete(DeleteBehavior.Cascade), // <- каскад при удалении жанра

                j => j
                    .HasOne<Game>()
                    .WithMany()
                    .HasForeignKey("GameId")
                    .OnDelete(DeleteBehavior.Cascade), // <- каскад при удалении игры

                j =>
                {
                    j.HasKey("GameId", "GenreId");
                    j.ToTable("GameGenres");
                }
            );*/



    }
}