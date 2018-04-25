using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MobiBooking.Migrations
{
    public partial class DeletedStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingsCurrentMonth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MeetingsCurrentWeek",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MeetingsPastMonth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MeetingsPastWeek",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReservationCurrentMonth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReservationCurrentWeek",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReservationPastMonth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReservationPastWeek",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MeetingsCurrentMonth",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MeetingsCurrentWeek",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MeetingsPastMonth",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MeetingsPastWeek",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationCurrentMonth",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationCurrentWeek",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationPastMonth",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationPastWeek",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }
    }
}
