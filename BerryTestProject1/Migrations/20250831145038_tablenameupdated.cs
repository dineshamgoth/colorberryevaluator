using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerryTestProject1.Migrations
{
    /// <inheritdoc />
    public partial class tablenameupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_Relationship_RelationshipId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_Relationship_RelationshipId",
                table: "Score");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.RenameColumn(
                name: "RelationshipId",
                table: "Score",
                newName: "PersonDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_RelationshipId",
                table: "Score",
                newName: "IX_Score_PersonDetailsId");

            migrationBuilder.RenameColumn(
                name: "RelationshipId",
                table: "Response",
                newName: "PersonDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Response_RelationshipId",
                table: "Response",
                newName: "IX_Response_PersonDetailsId");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Statement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Statement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Score",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ResultCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ResultCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    PersonDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    YearsKnown = table.Column<int>(type: "int", nullable: false),
                    InteractionFrequency = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.PersonDetailsId);
                    table.ForeignKey(
                        name: "FK_PersonDetails_UserData_UserId",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 816, DateTimeKind.Local).AddTicks(6563), new DateTime(2025, 8, 31, 20, 20, 36, 817, DateTimeKind.Local).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(807), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(813), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(814) });

            migrationBuilder.UpdateData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(815), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(816), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(817) });

            migrationBuilder.UpdateData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(818), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(818) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(7098), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(7101) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8223), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8225) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8228), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8229) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8230), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8231), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8233), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8233) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8234), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8234) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8235), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8236) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8237), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8237) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8238), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8240), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8240) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8242), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8243) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8244), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8244) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8287), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8288) });

            migrationBuilder.UpdateData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8289), new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8289) });

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetails_UserId",
                table: "PersonDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_PersonDetails_PersonDetailsId",
                table: "Response",
                column: "PersonDetailsId",
                principalTable: "PersonDetails",
                principalColumn: "PersonDetailsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_PersonDetails_PersonDetailsId",
                table: "Score",
                column: "PersonDetailsId",
                principalTable: "PersonDetails",
                principalColumn: "PersonDetailsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_PersonDetails_PersonDetailsId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_PersonDetails_PersonDetailsId",
                table: "Score");

            migrationBuilder.DropTable(
                name: "PersonDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ResultCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ResultCategory");

            migrationBuilder.RenameColumn(
                name: "PersonDetailsId",
                table: "Score",
                newName: "RelationshipId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_PersonDetailsId",
                table: "Score",
                newName: "IX_Score_RelationshipId");

            migrationBuilder.RenameColumn(
                name: "PersonDetailsId",
                table: "Response",
                newName: "RelationshipId");

            migrationBuilder.RenameIndex(
                name: "IX_Response_PersonDetailsId",
                table: "Response",
                newName: "IX_Response_RelationshipId");

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    RelationshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    InteractionFrequency = table.Column<int>(type: "int", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearsKnown = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.RelationshipId);
                    table.ForeignKey(
                        name: "FK_Relationship_UserData_UserId",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_UserId",
                table: "Relationship",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Relationship_RelationshipId",
                table: "Response",
                column: "RelationshipId",
                principalTable: "Relationship",
                principalColumn: "RelationshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Relationship_RelationshipId",
                table: "Score",
                column: "RelationshipId",
                principalTable: "Relationship",
                principalColumn: "RelationshipId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
