using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M1_PANGAN.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureLogFkCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Items_ItemId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_ItemId",
                table: "Logs");
        }
    }
}
