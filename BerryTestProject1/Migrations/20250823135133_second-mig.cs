using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerryTestProject1.Migrations
{
    /// <inheritdoc />
    public partial class secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_UserDatas_UserId",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Relationships_RelationshipId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Statements_StatementId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Relationships_RelationshipId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_ResultCategories_ResultCategoryId",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDatas",
                table: "UserDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statements",
                table: "Statements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultCategories",
                table: "ResultCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relationships",
                table: "Relationships");

            migrationBuilder.RenameTable(
                name: "UserDatas",
                newName: "UserData");

            migrationBuilder.RenameTable(
                name: "Statements",
                newName: "Statement");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.RenameTable(
                name: "ResultCategories",
                newName: "ResultCategorie");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "Response");

            migrationBuilder.RenameTable(
                name: "Relationships",
                newName: "Relationship");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_ResultCategoryId",
                table: "Score",
                newName: "IX_Score_ResultCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_RelationshipId",
                table: "Score",
                newName: "IX_Score_RelationshipId");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_StatementId",
                table: "Response",
                newName: "IX_Response_StatementId");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_RelationshipId",
                table: "Response",
                newName: "IX_Response_RelationshipId");

            migrationBuilder.RenameIndex(
                name: "IX_Relationships_UserId",
                table: "Relationship",
                newName: "IX_Relationship_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserData",
                table: "UserData",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statement",
                table: "Statement",
                column: "StatementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Score",
                table: "Score",
                column: "ScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultCategorie",
                table: "ResultCategorie",
                column: "ResultCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Response",
                table: "Response",
                column: "ResponseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relationship",
                table: "Relationship",
                column: "RelationshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationship_UserData_UserId",
                table: "Relationship",
                column: "UserId",
                principalTable: "UserData",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Relationship_RelationshipId",
                table: "Response",
                column: "RelationshipId",
                principalTable: "Relationship",
                principalColumn: "RelationshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Statement_StatementId",
                table: "Response",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Relationship_RelationshipId",
                table: "Score",
                column: "RelationshipId",
                principalTable: "Relationship",
                principalColumn: "RelationshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_ResultCategorie_ResultCategoryId",
                table: "Score",
                column: "ResultCategoryId",
                principalTable: "ResultCategorie",
                principalColumn: "ResultCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relationship_UserData_UserId",
                table: "Relationship");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Relationship_RelationshipId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Statement_StatementId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_Relationship_RelationshipId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_ResultCategorie_ResultCategoryId",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserData",
                table: "UserData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statement",
                table: "Statement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Score",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResultCategorie",
                table: "ResultCategorie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Response",
                table: "Response");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relationship",
                table: "Relationship");

            migrationBuilder.RenameTable(
                name: "UserData",
                newName: "UserDatas");

            migrationBuilder.RenameTable(
                name: "Statement",
                newName: "Statements");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.RenameTable(
                name: "ResultCategorie",
                newName: "ResultCategories");

            migrationBuilder.RenameTable(
                name: "Response",
                newName: "Responses");

            migrationBuilder.RenameTable(
                name: "Relationship",
                newName: "Relationships");

            migrationBuilder.RenameIndex(
                name: "IX_Score_ResultCategoryId",
                table: "Scores",
                newName: "IX_Scores_ResultCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_RelationshipId",
                table: "Scores",
                newName: "IX_Scores_RelationshipId");

            migrationBuilder.RenameIndex(
                name: "IX_Response_StatementId",
                table: "Responses",
                newName: "IX_Responses_StatementId");

            migrationBuilder.RenameIndex(
                name: "IX_Response_RelationshipId",
                table: "Responses",
                newName: "IX_Responses_RelationshipId");

            migrationBuilder.RenameIndex(
                name: "IX_Relationship_UserId",
                table: "Relationships",
                newName: "IX_Relationships_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDatas",
                table: "UserDatas",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statements",
                table: "Statements",
                column: "StatementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "ScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResultCategories",
                table: "ResultCategories",
                column: "ResultCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "ResponseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relationships",
                table: "Relationships",
                column: "RelationshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_UserDatas_UserId",
                table: "Relationships",
                column: "UserId",
                principalTable: "UserDatas",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Relationships_RelationshipId",
                table: "Responses",
                column: "RelationshipId",
                principalTable: "Relationships",
                principalColumn: "RelationshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Statements_StatementId",
                table: "Responses",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Relationships_RelationshipId",
                table: "Scores",
                column: "RelationshipId",
                principalTable: "Relationships",
                principalColumn: "RelationshipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_ResultCategories_ResultCategoryId",
                table: "Scores",
                column: "ResultCategoryId",
                principalTable: "ResultCategories",
                principalColumn: "ResultCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
