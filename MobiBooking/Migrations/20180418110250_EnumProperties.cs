using Microsoft.EntityFrameworkCore.Migrations;

namespace MobiBooking.Migrations
{
    public partial class EnumProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prop",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExtraEquip",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCycled",
                table: "Reservations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExtraEquip",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsCycled",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "prop",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);
        }
    }
}