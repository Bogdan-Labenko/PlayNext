using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayNextServer.Migrations
{
    /// <inheritdoc />
    public partial class kuhbawd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvolvedCompany_Games_GameId",
                table: "InvolvedCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvolvedCompany",
                table: "InvolvedCompany");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "InvolvedCompany");

            migrationBuilder.RenameTable(
                name: "InvolvedCompany",
                newName: "InvolvedCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_InvolvedCompany_GameId",
                table: "InvolvedCompanies",
                newName: "IX_InvolvedCompanies_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvolvedCompanies",
                table: "InvolvedCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvolvedCompanies_Games_GameId",
                table: "InvolvedCompanies",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvolvedCompanies_Games_GameId",
                table: "InvolvedCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvolvedCompanies",
                table: "InvolvedCompanies");

            migrationBuilder.RenameTable(
                name: "InvolvedCompanies",
                newName: "InvolvedCompany");

            migrationBuilder.RenameIndex(
                name: "IX_InvolvedCompanies_GameId",
                table: "InvolvedCompany",
                newName: "IX_InvolvedCompany_GameId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "InvolvedCompany",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvolvedCompany",
                table: "InvolvedCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvolvedCompany_Games_GameId",
                table: "InvolvedCompany",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
