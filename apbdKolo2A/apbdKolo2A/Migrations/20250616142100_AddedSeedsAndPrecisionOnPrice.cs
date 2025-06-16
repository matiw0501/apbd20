using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbdKolo2A.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedsAndPrecisionOnPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "AvailablePrograms",
                type: "float(10)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski", "111-222-333" },
                    { 2, "Krzysztof", "Zalewski", "333-444-555" },
                    { 3, "Aleksander", "Ciesla", "666-777-888" }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "DurationMinutes", "Name", "TemperatureCelsius" },
                values: new object[,]
                {
                    { 1, 20, "Szybkie", 50 },
                    { 2, 120, "Delikatne", 30 },
                    { 3, 60, "Sportowe", 40 }
                });

            migrationBuilder.InsertData(
                table: "WashingMachines",
                columns: new[] { "WashingMachineId", "MaxWeight", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 20.0, "PDW123456" },
                    { 2, 12.0, "PDW987654" },
                    { 3, 5.5, "PDW673028" }
                });

            migrationBuilder.InsertData(
                table: "AvailablePrograms",
                columns: new[] { "AvailableProgramId", "Price", "ProgramId", "WashingMachineId" },
                values: new object[,]
                {
                    { 1, 10.99, 1, 1 },
                    { 2, 12.5, 2, 1 },
                    { 3, 14.0, 2, 2 },
                    { 4, 11.6, 3, 2 },
                    { 5, 20.0, 1, 3 },
                    { 6, 6.5999999999999996, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseHistories",
                columns: new[] { "AvailableProgramId", "CustomerId", "PurchaseDate", "Rating" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 2, new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PurchaseHistories",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PurchaseHistories",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PurchaseHistories",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WashingMachines",
                keyColumn: "WashingMachineId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WashingMachines",
                keyColumn: "WashingMachineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WashingMachines",
                keyColumn: "WashingMachineId",
                keyValue: 2);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "AvailablePrograms",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(10)",
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
