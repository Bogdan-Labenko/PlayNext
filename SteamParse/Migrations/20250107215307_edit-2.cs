using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SteamParse.Migrations
{
    /// <inheritdoc />
    public partial class edit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PriceChangeNumber",
                table: "Games",
                newName: "RequiredAge");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "Games",
                newName: "SteamId");

            migrationBuilder.AddColumn<string>(
                name: "ControllerSupport",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string[]>(
                name: "Developers",
                table: "Games",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<int[]>(
                name: "Dlcs",
                table: "Games",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<string>(
                name: "HeaderImage",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Games",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MetacriticId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlatformsId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceOverviewId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string[]>(
                name: "Publishers",
                table: "Games",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<int>(
                name: "ReleaseDateId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupportedLanguages",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    GameSteamId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Games_GameSteamId",
                        column: x => x.GameSteamId,
                        principalTable: "Games",
                        principalColumn: "SteamId");
                });

            migrationBuilder.CreateTable(
                name: "GamesInfo",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    PriceChangeNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesInfo", x => x.AppId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    GameSteamId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Games_GameSteamId",
                        column: x => x.GameSteamId,
                        principalTable: "Games",
                        principalColumn: "SteamId");
                });

            migrationBuilder.CreateTable(
                name: "Metacritics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metacritics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Windows = table.Column<bool>(type: "boolean", nullable: false),
                    Mac = table.Column<bool>(type: "boolean", nullable: false),
                    Linux = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceOverviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Initial = table.Column<int>(type: "integer", nullable: false),
                    Final = table.Column<int>(type: "integer", nullable: false),
                    DiscountPercent = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceOverviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComingSoon = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseDates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_MetacriticId",
                table: "Games",
                column: "MetacriticId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlatformsId",
                table: "Games",
                column: "PlatformsId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PriceOverviewId",
                table: "Games",
                column: "PriceOverviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ReleaseDateId",
                table: "Games",
                column: "ReleaseDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GameSteamId",
                table: "Categories",
                column: "GameSteamId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameSteamId",
                table: "Genres",
                column: "GameSteamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Metacritics_MetacriticId",
                table: "Games",
                column: "MetacriticId",
                principalTable: "Metacritics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Platforms_PlatformsId",
                table: "Games",
                column: "PlatformsId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_PriceOverviews_PriceOverviewId",
                table: "Games",
                column: "PriceOverviewId",
                principalTable: "PriceOverviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ReleaseDates_ReleaseDateId",
                table: "Games",
                column: "ReleaseDateId",
                principalTable: "ReleaseDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Metacritics_MetacriticId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Platforms_PlatformsId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_PriceOverviews_PriceOverviewId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_ReleaseDates_ReleaseDateId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "GamesInfo");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Metacritics");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "PriceOverviews");

            migrationBuilder.DropTable(
                name: "ReleaseDates");

            migrationBuilder.DropIndex(
                name: "IX_Games_MetacriticId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_PlatformsId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_PriceOverviewId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ReleaseDateId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ControllerSupport",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Developers",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Dlcs",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HeaderImage",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MetacriticId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlatformsId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PriceOverviewId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Publishers",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ReleaseDateId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SupportedLanguages",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "RequiredAge",
                table: "Games",
                newName: "PriceChangeNumber");

            migrationBuilder.RenameColumn(
                name: "SteamId",
                table: "Games",
                newName: "AppId");

            migrationBuilder.AddColumn<long>(
                name: "LastModified",
                table: "Games",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
