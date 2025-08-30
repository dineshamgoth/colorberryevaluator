using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerryTestProject1.Migrations
{
    /// <inheritdoc />
    public partial class Relationship_up1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonGender",
                table: "Relationship",
                newName: "InteractionFrequency");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Relationship",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Relationship");

            migrationBuilder.RenameColumn(
                name: "InteractionFrequency",
                table: "Relationship",
                newName: "PersonGender");
        }
    }
}
