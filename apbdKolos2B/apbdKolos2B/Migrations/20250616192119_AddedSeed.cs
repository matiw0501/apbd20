using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbdKolos2B.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ConcertId", "AvailableTickets", "Date", "Name" },
                values: new object[,]
                {
                    { 1, 20, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pielgrzymka" },
                    { 2, 100, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juwenalia" },
                    { 3, 300, new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Urysnalia" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Jane", "Kowalski", "999-999-999" },
                    { 2, "Krzysztof", "Zalewski", "777-777-777" },
                    { 3, "Grzegorz", "Floryda", null }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "SeatNumber", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 200, "PDW1111" },
                    { 2, 15, "PDW2222" },
                    { 3, 20, "PDW3333" }
                });

            migrationBuilder.InsertData(
                table: "TicketConcerts",
                columns: new[] { "TicketConcertId", "ConcertId", "Price", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, 15.99, 1 },
                    { 2, 2, 20.989999999999998, 1 },
                    { 3, 3, 27.870000000000001, 2 },
                    { 4, 1, 123.45, 3 },
                    { 5, 2, 112.98999999999999, 3 }
                });

            migrationBuilder.InsertData(
                table: "PurchasedTickets",
                columns: new[] { "CustomerId", "TicketConcertId", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2025, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchasedTickets",
                keyColumns: new[] { "CustomerId", "TicketConcertId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PurchasedTickets",
                keyColumns: new[] { "CustomerId", "TicketConcertId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PurchasedTickets",
                keyColumns: new[] { "CustomerId", "TicketConcertId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PurchasedTickets",
                keyColumns: new[] { "CustomerId", "TicketConcertId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PurchasedTickets",
                keyColumns: new[] { "CustomerId", "TicketConcertId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PurchasedTickets",
                keyColumns: new[] { "CustomerId", "TicketConcertId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "TicketConcerts",
                keyColumn: "TicketConcertId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketConcerts",
                keyColumn: "TicketConcertId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketConcerts",
                keyColumn: "TicketConcertId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketConcerts",
                keyColumn: "TicketConcertId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketConcerts",
                keyColumn: "TicketConcertId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "ConcertId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "ConcertId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "ConcertId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2);
        }
    }
}
