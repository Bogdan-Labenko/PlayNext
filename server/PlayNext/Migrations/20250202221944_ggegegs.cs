using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayNextServer.Migrations
{
    /// <inheritdoc />
    public partial class ggegegs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Games_GameId",
                table: "Covers");

            migrationBuilder.DropIndex(
                name: "IX_Covers_GameId",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Covers");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CoverId",
                table: "Games",
                column: "CoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Covers_CoverId",
                table: "Games",
                column: "CoverId",
                principalTable: "Covers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Covers_CoverId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CoverId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Covers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Covers_GameId",
                table: "Covers",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_Games_GameId",
                table: "Covers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
