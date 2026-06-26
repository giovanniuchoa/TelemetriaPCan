using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelemetriaPCan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_column_createdat_telemetry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Telemetry",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Telemetry");
        }
    }
}
