using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fc_manager_backend_da.Migrations
{
    public partial class ScheduledOntoScheduledAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledOn",
                table: "Matches");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledAt",
                table: "Matches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledAt",
                table: "Matches");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledOn",
                table: "Matches",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
