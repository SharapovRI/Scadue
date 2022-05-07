using Microsoft.EntityFrameworkCore.Migrations;

namespace Scadue.Data.Migrations
{
    public partial class AddedCascadeDeletingAdminUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdministrativeUnits_AdministrativeUnits_ParentAdminUnitId",
                table: "AdministrativeUnits");

            migrationBuilder.AddForeignKey(
                name: "FK_AdministrativeUnits_AdministrativeUnits_ParentAdminUnitId",
                table: "AdministrativeUnits",
                column: "ParentAdminUnitId",
                principalTable: "AdministrativeUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdministrativeUnits_AdministrativeUnits_ParentAdminUnitId",
                table: "AdministrativeUnits");

            migrationBuilder.AddForeignKey(
                name: "FK_AdministrativeUnits_AdministrativeUnits_ParentAdminUnitId",
                table: "AdministrativeUnits",
                column: "ParentAdminUnitId",
                principalTable: "AdministrativeUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
