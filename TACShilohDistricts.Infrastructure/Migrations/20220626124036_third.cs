using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TACShilohDistricts.Infrastructure.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "ContactUs",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "ContactUs");
        }
    }
}
