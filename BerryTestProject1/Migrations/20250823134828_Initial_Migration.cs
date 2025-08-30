using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BerryTestProject1.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultCategories",
                columns: table => new
                {
                    ResultCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CirclePlacement = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultCategories", x => x.ResultCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    StatementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssertiveStatement = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Score = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.StatementId);
                });

            migrationBuilder.CreateTable(
                name: "UserDatas",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDatas", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    RelationshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonGender = table.Column<int>(type: "int", nullable: false),
                    YearsKnown = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.RelationshipId);
                    table.ForeignKey(
                        name: "FK_Relationships_UserDatas_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDatas",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationshipId = table.Column<int>(type: "int", nullable: false),
                    StatementId = table.Column<int>(type: "int", nullable: false),
                    Intensity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Responses_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "RelationshipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responses_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "StatementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationshipId = table.Column<int>(type: "int", nullable: false),
                    FinalScore = table.Column<double>(type: "float", nullable: false),
                    ResultCategoryId = table.Column<int>(type: "int", nullable: false),
                    EvaluatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_Scores_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "RelationshipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_ResultCategories_ResultCategoryId",
                        column: x => x.ResultCategoryId,
                        principalTable: "ResultCategories",
                        principalColumn: "ResultCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ResultCategories",
                columns: new[] { "ResultCategoryId", "CirclePlacement", "ColorCode", "Message" },
                values: new object[,]
                {
                    { 1, "The Core", "blue", "Dear {user}, {name} is your heart and soul—an extraordinary, supportive companion. Never, ever leave or hurt {pronoun}." },
                    { 2, "The Inner Circle", "teal", "{user}, {name} is your loyal friend—an honest companion with whom your secrets are safe. {pronoun} is your true partner in crime." },
                    { 3, "The Allies", "white", "{name} is your supportive friend—a loyal and trusted companion. You may have temporary ego clashes, but the relationship is sustained with support and trust in the long run." },
                    { 4, "The Outer Circle", "green", "{name} is neither your trusted friend nor your enemy. The communication is situation-based, not exclusive." },
                    { 5, "The Quarantine Zone", "yellow", "You should probably limit your interaction with {name}. {pronoun} will drain your emotions for their own benefit." },
                    { 6, "The Exclusion Zone", "red", "Dear {user}, you are in a toxic relationship. Back away from {name} immediately to protect your mental peace." }
                });

            migrationBuilder.InsertData(
                table: "Statements",
                columns: new[] { "StatementId", "AssertiveStatement", "Category", "Score" },
                values: new object[,]
                {
                    { 1, "{name} loves you unconditionally, enhances your mood, and makes you smile.", "WellWisher", 5 },
                    { 2, "{name} encourages you to go beyond your limits and challenges you to grow.", "GrowthCatalyst", 4 },
                    { 3, "You feel safe and comfortable sharing your worst secrets with {name}.", "Protector", 4 },
                    { 4, "{name} will stand by you in tough times and encourages you to try new things.", "Supporter", 4 },
                    { 5, "{name} calms your heart and mind, bringing you back to your senses when you are a mess.", "Stabilizer", 3 },
                    { 6, "You automatically smile when you see {name}, and you share many happy memories together.", "JoyBringer", 3 },
                    { 7, "The dislike from {name} feels irrational and baseless, more like a reflection of their own issues.", "Hater", -5 },
                    { 8, "{name} has betrayed your trust or made you feel unimportant in your absence.", "Backstabber", -5 },
                    { 9, "{name} twists facts to gain an emotional advantage over you.", "Manipulator", -4 },
                    { 10, "{name} subtly chips away at your confidence with passive-aggressive remarks.", "Underminer", -4 },
                    { 11, "You sense a lack of genuine joy from {name} when you share good news.", "Envyer", -3 },
                    { 12, "{name} often exaggerates insignificant emotions to seek attention.", "DramaGenerator", -3 },
                    { 13, "When you share a dream or goal, {name} encourages you to play small or stay safe.", "Stagnator", -3 },
                    { 14, "{name} frequently uses your resources (time, money, energy) for their own benefit without gratitude.", "Leecher", -2 },
                    { 15, "{name} seems to feed on your emotional insecurities, providing no real benefit to you.", "EmotionalVulture", -2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_UserId",
                table: "Relationships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_RelationshipId",
                table: "Responses",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_StatementId",
                table: "Responses",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_RelationshipId",
                table: "Scores",
                column: "RelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ResultCategoryId",
                table: "Scores",
                column: "ResultCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "ResultCategories");

            migrationBuilder.DropTable(
                name: "UserDatas");
        }
    }
}
