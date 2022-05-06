using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Scadue.Data.Migrations
{
    public partial class ChangeCoordinatesToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitCoordinates");

            migrationBuilder.AddColumn<string>(
                name: "UnitCoordinates",
                table: "AdministrativeUnits",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitCoordinates",
                table: "AdministrativeUnits");

            migrationBuilder.CreateTable(
                name: "UnitCoordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Lat = table.Column<double>(type: "double precision", nullable: false),
                    Lon = table.Column<double>(type: "double precision", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitCoordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitCoordinates_AdministrativeUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "AdministrativeUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitCoordinates_UnitId",
                table: "UnitCoordinates",
                column: "UnitId");
        }
    }
}
