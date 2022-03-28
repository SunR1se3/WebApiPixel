using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPixel.Migrations.Migrations
{
    public partial class Change_Order_Ware : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_WareId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_WareId",
                table: "Order",
                column: "WareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_WareId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_WareId",
                table: "Order",
                column: "WareId",
                unique: true);
        }
    }
}
