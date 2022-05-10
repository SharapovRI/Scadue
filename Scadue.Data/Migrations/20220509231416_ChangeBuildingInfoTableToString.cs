using Microsoft.EntityFrameworkCore.Migrations;

namespace Scadue.Data.Migrations
{
    public partial class ChangeBuildingInfoTableToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "CenterLatitude",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "CenterLongitude",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "FloorsNumber",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Buildings",
                newName: "Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Buildings",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Buildings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CenterLatitude",
                table: "Buildings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CenterLongitude",
                table: "Buildings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Buildings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FloorsNumber",
                table: "Buildings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Buildings",
                type: "text",
                nullable: true);
        }
    }
}
