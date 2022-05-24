using Microsoft.EntityFrameworkCore.Migrations;

namespace Beacon.data.Migrations
{
    public partial class EditedSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InfoTextAz",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "InfoTextEn",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "InfoImage",
                table: "Settings",
                newName: "InfoIMage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InfoIMage",
                table: "Settings",
                newName: "InfoImage");

            migrationBuilder.AddColumn<string>(
                name: "InfoTextAz",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InfoTextEn",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
