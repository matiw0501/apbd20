using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Probny2025ZRozwiazaniem.Migrations
{
    /// <inheritdoc />
    public partial class AddedContextForOrdersCorrectedDynamicDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderedAt",
                value: new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderedAt",
                value: new DateTime(2025, 6, 15, 16, 40, 50, 633, DateTimeKind.Local).AddTicks(9154));
        }
    }
}
