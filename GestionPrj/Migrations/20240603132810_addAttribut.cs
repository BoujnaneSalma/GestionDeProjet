using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPrj.Migrations
{
    public partial class addAttribut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RScrums",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RScrums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeureDebut",
                table: "RScrums",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeureFin",
                table: "RScrums",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "RScrums");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RScrums");

            migrationBuilder.DropColumn(
                name: "HeureDebut",
                table: "RScrums");

            migrationBuilder.DropColumn(
                name: "HeureFin",
                table: "RScrums");
        }
    }
}
