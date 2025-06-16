using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbdKolos2B.Migrations
{
    /// <inheritdoc />
    public partial class AddedWithConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketConcerts",
                columns: table => new
                {
                    TicketConcertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    ConcertId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketConcerts", x => x.TicketConcertId);
                    table.ForeignKey(
                        name: "FK_TicketConcerts_Contracts_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Contracts",
                        principalColumn: "ConcertId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketConcerts_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedTickets",
                columns: table => new
                {
                    TicketConcertId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedTickets", x => new { x.TicketConcertId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_PurchasedTickets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedTickets_TicketConcerts_TicketConcertId",
                        column: x => x.TicketConcertId,
                        principalTable: "TicketConcerts",
                        principalColumn: "TicketConcertId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedTickets_CustomerId",
                table: "PurchasedTickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketConcerts_ConcertId",
                table: "TicketConcerts",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketConcerts_TicketId",
                table: "TicketConcerts",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedTickets");

            migrationBuilder.DropTable(
                name: "TicketConcerts");
        }
    }
}
