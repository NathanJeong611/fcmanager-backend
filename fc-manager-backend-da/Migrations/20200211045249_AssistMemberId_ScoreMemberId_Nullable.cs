using Microsoft.EntityFrameworkCore.Migrations;

namespace fc_manager_backend_da.Migrations
{
    public partial class AssistMemberId_ScoreMemberId_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_AssistMemberId",
                table: "MatchRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_ScoreMemberId",
                table: "MatchRecords");

            migrationBuilder.AlterColumn<int>(
                name: "ScoreMemberId",
                table: "MatchRecords",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "AssistMemberId",
                table: "MatchRecords",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_AssistMemberId",
                table: "MatchRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchRecords_Members_ScoreMemberId",
                table: "MatchRecords");

            migrationBuilder.AlterColumn<int>(
                name: "ScoreMemberId",
                table: "MatchRecords",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssistMemberId",
                table: "MatchRecords",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_AssistMemberId",
                table: "MatchRecords",
                column: "AssistMemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRecords_Members_ScoreMemberId",
                table: "MatchRecords",
                column: "ScoreMemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
