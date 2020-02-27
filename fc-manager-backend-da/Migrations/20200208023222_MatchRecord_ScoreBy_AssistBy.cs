using Microsoft.EntityFrameworkCore.Migrations;

namespace fc_manager_backend_da.Migrations
{
    public partial class MatchRecord_ScoreBy_AssistBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_AssistMemberId",
                table: "MatchRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_Member",
                table: "MatchRecords");

            migrationBuilder.DropIndex(
                name: "IX_MatchRecords_AssistMemberId",
                table: "MatchRecords");

            migrationBuilder.DropIndex(
                name: "IX_MatchRecords_Member",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "AssistMemberId",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "Member",
                table: "MatchRecords");

            migrationBuilder.AddColumn<int>(
                name: "AssistBy",
                table: "MatchRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoreBy",
                table: "MatchRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_AssistBy",
                table: "MatchRecords",
                column: "AssistBy");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_ScoreBy",
                table: "MatchRecords",
                column: "ScoreBy");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_AssistBy",
                table: "MatchRecords",
                column: "AssistBy",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_ScoreBy",
                table: "MatchRecords",
                column: "ScoreBy",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_AssistBy",
                table: "MatchRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_ScoreBy",
                table: "MatchRecords");

            migrationBuilder.DropIndex(
                name: "IX_MatchRecords_AssistBy",
                table: "MatchRecords");

            migrationBuilder.DropIndex(
                name: "IX_MatchRecords_ScoreBy",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "AssistBy",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "ScoreBy",
                table: "MatchRecords");

            migrationBuilder.AddColumn<int>(
                name: "AssistMemberId",
                table: "MatchRecords",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Member",
                table: "MatchRecords",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_AssistMemberId",
                table: "MatchRecords",
                column: "AssistMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_Member",
                table: "MatchRecords",
                column: "Member");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_AssistMemberId",
                table: "MatchRecords",
                column: "AssistMemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_Member",
                table: "MatchRecords",
                column: "Member",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
