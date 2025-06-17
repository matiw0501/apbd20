using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbdKolos2ProbnyTest.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[,]
                {
                    { 1, 60, "Jan", "Kowalski", 80 },
                    { 2, 50, "Krzysztof", "Zalewski", 65 },
                    { 3, 65, "Jakub", "Cash", 92 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Puszka", 3 },
                    { 2, "Latarka", 1 },
                    { 3, "Zapalniczka", 1 }
                });

            migrationBuilder.InsertData(
                table: "Titiles",
                columns: new[] { "TitileId", "Name" },
                values: new object[,]
                {
                    { 1, "Technik" },
                    { 2, "Inzynier" },
                    { 3, "Kucharz" }
                });

            migrationBuilder.InsertData(
                table: "Backpacks",
                columns: new[] { "CharacterdId", "ItemId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 1, 2, 1 },
                    { 1, 3, 2 },
                    { 2, 1, 2 },
                    { 2, 3, 1 },
                    { 3, 1, 8 },
                    { 3, 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "CharacterTitles",
                columns: new[] { "CharacterId", "TitileId", "AcquiredAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterdId", "ItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterdId", "ItemId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterdId", "ItemId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterdId", "ItemId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterdId", "ItemId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterdId", "ItemId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterdId", "ItemId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterTitles",
                keyColumns: new[] { "CharacterId", "TitileId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterTitles",
                keyColumns: new[] { "CharacterId", "TitileId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterTitles",
                keyColumns: new[] { "CharacterId", "TitileId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterTitles",
                keyColumns: new[] { "CharacterId", "TitileId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterTitles",
                keyColumns: new[] { "CharacterId", "TitileId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Titiles",
                keyColumn: "TitileId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Titiles",
                keyColumn: "TitileId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Titiles",
                keyColumn: "TitileId",
                keyValue: 3);
        }
    }
}
