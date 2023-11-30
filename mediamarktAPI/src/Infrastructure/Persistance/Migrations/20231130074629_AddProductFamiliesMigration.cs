using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddProductFamiliesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.InsertData(
                table: "ProductFamily",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6"), "Coffe machines" },
                    { new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6"), "Smartphones" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "TV" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductFamily",
                keyColumn: "Id",
                keyValue: new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "ProductFamily",
                keyColumn: "Id",
                keyValue: new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "ProductFamily",
                keyColumn: "Id",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Orbit_OrbitalPeriod = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Orbit_OrbitalRadius = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Orbit_RotationPeriod = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });
        }
    }
}
