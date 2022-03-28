using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPixel.Migrations.Migrations
{
    public partial class DeletePropOnDeleteNoAction_WareConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Ware",
                table: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Ware",
                table: "Order",
                column: "WareId",
                principalTable: "Ware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Ware",
                table: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Ware",
                table: "Order",
                column: "WareId",
                principalTable: "Ware",
                principalColumn: "Id");
        }
    }
}
