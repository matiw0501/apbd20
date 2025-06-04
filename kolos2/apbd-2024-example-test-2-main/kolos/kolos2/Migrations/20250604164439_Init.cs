using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kolos2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    ConcertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableTickets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.ConcertId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Ticket_Concerts",
                columns: table => new
                {
                    TicketConcertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    ConcertId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_Concerts", x => x.TicketConcertId);
                    table.ForeignKey(
                        name: "FK_Ticket_Concerts_Concerts_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concerts",
                        principalColumn: "ConcertId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Concerts_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    TicketConcertId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => new { x.TicketConcertId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Purchase_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Ticket_Concerts_TicketConcertId",
                        column: x => x.TicketConcertId,
                        principalTable: "Ticket_Concerts",
                        principalColumn: "TicketConcertId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Concerts",
                columns: new[] { "ConcertId", "AvailableTickets", "Date", "Name" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juwenalia" },
                    { 2, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ursynalia" },
                    { 3, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mokotonalia" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "555-555-5555" },
                    { 2, "Jane", "Doe", "555-555-5555" },
                    { 3, "Marry", "Starsky", "444-4444-4444" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "SeatNumber", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 124, "SN132836126" },
                    { 2, 330, "SN126846192" }
                });

            migrationBuilder.InsertData(
                table: "Ticket_Concerts",
                columns: new[] { "TicketConcertId", "ConcertId", "Price", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, 12m, 1 },
                    { 2, 2, 10m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Purchase",
                columns: new[] { "CustomerId", "TicketConcertId", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 3, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2025, 6, 3, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Concerts_ConcertId",
                table: "Ticket_Concerts",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Concerts_TicketId",
                table: "Ticket_Concerts",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Ticket_Concerts");

            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
