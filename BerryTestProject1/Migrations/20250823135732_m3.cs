using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerryTestProject1.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_ResultCategorie_ResultCategoryId",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultCategorie",
                table: "ResultCategorie");

            migrationBuilder.RenameTable(
                name: "ResultCategorie",
                newName: "ResultCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultCategory",
                table: "ResultCategory",
                column: "ResultCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_ResultCategory_ResultCategoryId",
                table: "Score",
                column: "ResultCategoryId",
                principalTable: "ResultCategory",
                principalColumn: "ResultCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_ResultCategory_ResultCategoryId",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultCategory",
                table: "ResultCategory");

            migrationBuilder.RenameTable(
                name: "ResultCategory",
                newName: "ResultCategorie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultCategorie",
                table: "ResultCategorie",
                column: "ResultCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_ResultCategorie_ResultCategoryId",
                table: "Score",
                column: "ResultCategoryId",
                principalTable: "ResultCategorie",
                principalColumn: "ResultCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
