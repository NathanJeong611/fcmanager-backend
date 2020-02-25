using Microsoft.EntityFrameworkCore.Migrations;

namespace fc_manager_backend_da.Migrations
{
    public partial class MatchRecord_Score_Assist_Divide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_ScoreMemberId",
                table: "MatchRecords");

            migrationBuilder.DropIndex(
                name: "IX_MatchRecords_ScoreMemberId",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "AssistBy",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "ScoreBy",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "ScoreMemberId",
                table: "MatchRecords");

            migrationBuilder.AddColumn<int>(
                name: "Member",
                table: "MatchRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_Member",
                table: "MatchRecords",
                column: "Member");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_Member",
                table: "MatchRecords",
                column: "Member",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_Member",
                table: "MatchRecords");

            migrationBuilder.DropIndex(
                name: "IX_MatchRecords_Member",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "Member",
                table: "MatchRecords");

            migrationBuilder.AddColumn<int>(
                name: "AssistBy",
                table: "MatchRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreBy",
                table: "MatchRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreMemberId",
                table: "MatchRecords",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_ScoreMemberId",
                table: "MatchRecords",
                column: "ScoreMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_ScoreMemberId",
                table: "MatchRecords",
                column: "ScoreMemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
