using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Scadue.Data.Migrations
{
    public partial class Init_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministrativeUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ISO3166 = table.Column<string>(type: "text", nullable: true),
                    AdminLevel = table.Column<int>(type: "integer", nullable: false),
                    ParentAdminUnitId = table.Column<int>(type: "integer", nullable: false),
                    Population = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CenterLatitude = table.Column<decimal>(type: "numeric", nullable: false),
                    CenterLongitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministrativeUnits_AdministrativeUnits_ParentAdminUnitId",
                        column: x => x.ParentAdminUnitId,
                        principalTable: "AdministrativeUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeUnits_ParentAdminUnitId",
                table: "AdministrativeUnits",
                column: "ParentAdminUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministrativeUnits");
        }
    }
}
