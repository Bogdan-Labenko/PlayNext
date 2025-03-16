using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayNextServer.Migrations
{
    /// <inheritdoc />
    public partial class edit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Collections");

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Covers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Collections",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CollectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Checksum = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_TypeId",
                table: "Collections",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_CollectionTypes_TypeId",
                table: "Collections",
                column: "TypeId",
                principalTable: "CollectionTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_CollectionTypes_TypeId",
                table: "Collections");

            migrationBuilder.DropTable(
                name: "CollectionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Collections_TypeId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Collections");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Covers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Collections",
                type: "text",
                nullable: true);
        }
    }
}
