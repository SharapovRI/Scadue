using Microsoft.EntityFrameworkCore.Migrations;

namespace Scadue.Data.Migrations
{
    public partial class ChangedDecimalToFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "CenterLongitude",
                table: "AdministrativeUnits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<float>(
                name: "CenterLatitude",
                table: "AdministrativeUnits",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "AdministrativeUnits",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "AdministrativeUnits");

            migrationBuilder.AlterColumn<decimal>(
                name: "CenterLongitude",
                table: "AdministrativeUnits",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "CenterLatitude",
                table: "AdministrativeUnits",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
