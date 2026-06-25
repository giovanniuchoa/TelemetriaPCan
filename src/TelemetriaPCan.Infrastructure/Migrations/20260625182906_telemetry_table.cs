using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelemetriaPCan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class telemetry_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Telemetry",
                columns: table => new
                {
                    IdTelemetry = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    IdVehicle = table.Column<int>(type: "int", nullable: false),
                    FuelLevel = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telemetry", x => x.IdTelemetry);
                    table.ForeignKey(
                        name: "FK_Telemetry_Vehicle_IdVehicle",
                        column: x => x.IdVehicle,
                        principalTable: "Vehicle",
                        principalColumn: "IdVehicle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telemetry_IdVehicle",
                table: "Telemetry",
                column: "IdVehicle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telemetry");
        }
    }
}
