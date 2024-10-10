using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatikaSurvivor.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1286), false, new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1268), "Ünlüler" },
                    { 2, new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1290), false, new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1290), "Gönüllüler" }
                });

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "FirstName", "IsDeleted", "LastName", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1397), "Acun", false, "Ilıcalı", new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1396) },
                    { 2, 2, new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1399), "Fatih", false, "Terim", new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1399) },
                    { 3, 1, new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1401), "Sezen", false, "Aksu", new DateTime(2024, 10, 10, 10, 46, 42, 475, DateTimeKind.Local).AddTicks(1400) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
