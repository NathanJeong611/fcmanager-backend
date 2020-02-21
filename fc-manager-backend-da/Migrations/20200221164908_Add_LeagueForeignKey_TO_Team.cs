using Microsoft.EntityFrameworkCore.Migrations;

namespace fc_manager_backend_da.Migrations
{
    public partial class Add_LeagueForeignKey_TO_Team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Teams",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Teams");
        }
    }
}
