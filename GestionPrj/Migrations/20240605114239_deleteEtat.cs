using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPrj.Migrations
{
    public partial class deleteEtat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Projets_ProjetId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_RScrums_RScrumId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "Etat",
                table: "Projets");

            migrationBuilder.AlterColumn<int>(
                name: "RScrumId",
                table: "Sprints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetId",
                table: "Sprints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Projets_ProjetId",
                table: "Sprints",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_RScrums_RScrumId",
                table: "Sprints",
                column: "RScrumId",
                principalTable: "RScrums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Projets_ProjetId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_RScrums_RScrumId",
                table: "Sprints");

            migrationBuilder.AlterColumn<int>(
                name: "RScrumId",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjetId",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Etat",
                table: "Projets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Projets_ProjetId",
                table: "Sprints",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_RScrums_RScrumId",
                table: "Sprints",
                column: "RScrumId",
                principalTable: "RScrums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
