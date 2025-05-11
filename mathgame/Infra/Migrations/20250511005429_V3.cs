using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mathgame.Infra.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Operations_OperationId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "OperationId",
                table: "Questions",
                newName: "OperationDifficultiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_OperationId",
                table: "Questions",
                newName: "IX_Questions_OperationDifficultiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Operation_Difficulties_OperationDifficultiesId",
                table: "Questions",
                column: "OperationDifficultiesId",
                principalTable: "Operation_Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Operation_Difficulties_OperationDifficultiesId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "OperationDifficultiesId",
                table: "Questions",
                newName: "OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_OperationDifficultiesId",
                table: "Questions",
                newName: "IX_Questions_OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Operations_OperationId",
                table: "Questions",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
