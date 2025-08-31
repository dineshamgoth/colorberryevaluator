using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BerryTestProject1.Migrations
{
    /// <inheritdoc />
    public partial class tablechanged2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ResultCategory",
                keyColumn: "ResultCategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Statement",
                keyColumn: "StatementId",
                keyValue: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ResultCategory",
                columns: new[] { "ResultCategoryId", "CirclePlacement", "ColorCode", "CreatedAt", "Message", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "The Core", "blue", new DateTime(2025, 8, 31, 20, 20, 36, 816, DateTimeKind.Local).AddTicks(6563), "Dear {user}, {name} is your heart and soul—an extraordinary, supportive companion. Never, ever leave or hurt {pronoun}.", new DateTime(2025, 8, 31, 20, 20, 36, 817, DateTimeKind.Local).AddTicks(9538) },
                    { 2, "The Inner Circle", "teal", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(807), "{user}, {name} is your loyal friend—an honest companion with whom your secrets are safe. {pronoun} is your true partner in crime.", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(810) },
                    { 3, "The Allies", "white", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(813), "{name} is your supportive friend—a loyal and trusted companion. You may have temporary ego clashes, but the relationship is sustained with support and trust in the long run.", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(814) },
                    { 4, "The Outer Circle", "green", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(815), "{name} is neither your trusted friend nor your enemy. The communication is situation-based, not exclusive.", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(815) },
                    { 5, "The Quarantine Zone", "yellow", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(816), "You should probably limit your interaction with {name}. {pronoun} will drain your emotions for their own benefit.", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(817) },
                    { 6, "The Exclusion Zone", "red", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(818), "Dear {user}, you are in a toxic relationship. Back away from {name} immediately to protect your mental peace.", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(818) }
                });

            migrationBuilder.InsertData(
                table: "Statement",
                columns: new[] { "StatementId", "AssertiveStatement", "Category", "CreatedAt", "Score", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "{name} loves you unconditionally, enhances your mood, and makes you smile.", "WellWisher", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(7098), 5, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(7101) },
                    { 2, "{name} encourages you to go beyond your limits and challenges you to grow.", "GrowthCatalyst", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8223), 4, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8225) },
                    { 3, "You feel safe and comfortable sharing your worst secrets with {name}.", "Protector", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8228), 4, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8229) },
                    { 4, "{name} will stand by you in tough times and encourages you to try new things.", "Supporter", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8230), 4, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8230) },
                    { 5, "{name} calms your heart and mind, bringing you back to your senses when you are a mess.", "Stabilizer", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8231), 3, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8232) },
                    { 6, "You automatically smile when you see {name}, and you share many happy memories together.", "JoyBringer", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8233), 3, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8233) },
                    { 7, "The dislike from {name} feels irrational and baseless, more like a reflection of their own issues.", "Hater", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8234), -5, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8234) },
                    { 8, "{name} has betrayed your trust or made you feel unimportant in your absence.", "Backstabber", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8235), -5, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8236) },
                    { 9, "{name} twists facts to gain an emotional advantage over you.", "Manipulator", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8237), -4, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8237) },
                    { 10, "{name} subtly chips away at your confidence with passive-aggressive remarks.", "Underminer", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8238), -4, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8239) },
                    { 11, "You sense a lack of genuine joy from {name} when you share good news.", "Envyer", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8240), -3, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8240) },
                    { 12, "{name} often exaggerates insignificant emotions to seek attention.", "DramaGenerator", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8242), -3, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8243) },
                    { 13, "When you share a dream or goal, {name} encourages you to play small or stay safe.", "Stagnator", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8244), -3, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8244) },
                    { 14, "{name} frequently uses your resources (time, money, energy) for their own benefit without gratitude.", "Leecher", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8287), -2, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8288) },
                    { 15, "{name} seems to feed on your emotional insecurities, providing no real benefit to you.", "EmotionalVulture", new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8289), -2, new DateTime(2025, 8, 31, 20, 20, 36, 818, DateTimeKind.Local).AddTicks(8289) }
                });
        }
    }
}
