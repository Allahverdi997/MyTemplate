using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class thirdMi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ExceptionNotifications",
                type: "nvarchar(500)",
                nullable: false,
                collation: "Cyrillic_General_CI_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ExceptionNotifications",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldCollation: "Cyrillic_General_CI_AS");
        }
    }
}
