using Microsoft.EntityFrameworkCore.Migrations;

namespace Beacon.data.Migrations
{
    public partial class AddedInSettingTableAboutColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutCompanyAz",
                table: "Settings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutCompanyEn",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutCompanyAz",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutCompanyEn",
                table: "Settings");
        }
    }
}
