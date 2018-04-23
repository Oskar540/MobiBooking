using Microsoft.EntityFrameworkCore.Migrations;

namespace MobiBooking.Migrations
{
    public partial class AddedPropStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "prop",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prop",
                table: "Users");
        }
    }
}