using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M1_PANGAN.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Items_ItemId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_ItemId",
                table: "Logs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimestampUtc",
                table: "Logs",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimestampUtc",
                table: "Logs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ItemId",
                table: "Logs",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Items_ItemId",
                table: "Logs",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
