using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class secondMi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Departments",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "LangId",
                table: "ExceptionNotifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shortname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionNotifications_LangId",
                table: "ExceptionNotifications",
                column: "LangId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExceptionNotifications_Languages_LangId",
                table: "ExceptionNotifications",
                column: "LangId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExceptionNotifications_Languages_LangId",
                table: "ExceptionNotifications");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_ExceptionNotifications_LangId",
                table: "ExceptionNotifications");

            migrationBuilder.DropColumn(
                name: "LangId",
                table: "ExceptionNotifications");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Departments",
                newName: "Surname");
        }
    }
}
