using Microsoft.EntityFrameworkCore.Migrations;

namespace fc_manager_backend_da.Migrations
{
    public partial class MatchRecord_Score_Assist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_MemberId",
                table: "MatchRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_MatchRecords_MemberId",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "MatchRecords");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamMembers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssistBy",
                table: "MatchRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AssistMemberId",
                table: "MatchRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoreBy",
                table: "MatchRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreMemberId",
                table: "MatchRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_AssistMemberId",
                table: "MatchRecords",
                column: "AssistMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_ScoreMemberId",
                table: "MatchRecords",
                column: "ScoreMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_AssistMemberId",
                table: "MatchRecords",
                column: "AssistMemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_ScoreMemberId",
                table: "MatchRecords",
                column: "ScoreMemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_AssistMemberId",
                table: "MatchRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_ScoreMemberId",
                table: "MatchRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_MatchRecords_AssistMemberId",
                table: "MatchRecords");

            migrationBuilder.DropIndex(
                name: "IX_MatchRecords_ScoreMemberId",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "AssistBy",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "AssistMemberId",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "ScoreBy",
                table: "MatchRecords");

            migrationBuilder.DropColumn(
                name: "ScoreMemberId",
                table: "MatchRecords");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamMembers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "MatchRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_MemberId",
                table: "MatchRecords",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_MemberId",
                table: "MatchRecords",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
