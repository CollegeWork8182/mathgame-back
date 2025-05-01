using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mathgame.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordChangeCode",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "AccessCodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsUserUpdatePassword = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExperationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessCodes_UserId",
                table: "AccessCodes",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessCodes");

            migrationBuilder.AddColumn<string>(
                name: "PasswordChangeCode",
                table: "Users",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
