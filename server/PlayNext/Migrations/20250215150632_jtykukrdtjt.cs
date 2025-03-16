using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayNextServer.Migrations
{
    /// <inheritdoc />
    public partial class jtykukrdtjt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameVideos_Games_GameId",
                table: "GameVideos");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GameVideos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_GameVideos_Games_GameId",
                table: "GameVideos",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameVideos_Games_GameId",
                table: "GameVideos");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GameVideos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameVideos_Games_GameId",
                table: "GameVideos",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
