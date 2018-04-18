using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MobiBooking.Migrations
{
    public partial class AddIdentityUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Users",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Users",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "localization",
                table: "Rooms",
                newName: "Localization");

            migrationBuilder.RenameColumn(
                name: "isReserved",
                table: "Rooms",
                newName: "IsReserved");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Rooms",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "etimeOption",
                table: "Rooms",
                newName: "EtimeOption");

            migrationBuilder.RenameColumn(
                name: "ebookStatus",
                table: "Rooms",
                newName: "EbookStatus");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Rooms",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "to",
                table: "Reservations",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "from",
                table: "Reservations",
                newName: "From");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Reservations",
                newName: "Capacity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Users",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rooms",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Localization",
                table: "Rooms",
                newName: "localization");

            migrationBuilder.RenameColumn(
                name: "IsReserved",
                table: "Rooms",
                newName: "isReserved");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Rooms",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "EtimeOption",
                table: "Rooms",
                newName: "etimeOption");

            migrationBuilder.RenameColumn(
                name: "EbookStatus",
                table: "Rooms",
                newName: "ebookStatus");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Rooms",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Reservations",
                newName: "to");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Reservations",
                newName: "from");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Reservations",
                newName: "capacity");
        }
    }
}
