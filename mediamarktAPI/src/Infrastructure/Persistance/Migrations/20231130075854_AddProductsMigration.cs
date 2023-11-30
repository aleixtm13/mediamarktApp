using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "ProductFamilyId" },
                values: new object[,]
                {
                    { new Guid("05f55fe5-10c2-47f6-b697-894bf97a74d7"), "iPhone 15 Pro Max Description", "iPhone 15 Pro Max", 1449.99, new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6") },
                    { new Guid("9a798e06-63f7-4443-9377-a261746ecdf8"), "Delonghi Dedica Description", "Delonghi Dedica EC685.BK", 199.99000000000001, new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6") },
                    { new Guid("afdafaf7-a558-4bbb-80dd-acb01442e251"), "LG TV Description", "LG OLED65C35LA, OLED 4K", 1599.0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("05f55fe5-10c2-47f6-b697-894bf97a74d7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a798e06-63f7-4443-9377-a261746ecdf8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("afdafaf7-a558-4bbb-80dd-acb01442e251"));
        }
    }
}
