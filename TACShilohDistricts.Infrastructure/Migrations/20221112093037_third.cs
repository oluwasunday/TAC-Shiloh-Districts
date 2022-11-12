using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TACShilohDistricts.Infrastructure.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEvents",
                table: "NewsAndEvents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfEvents",
                table: "NewsAndEvents");
        }
    }
}
