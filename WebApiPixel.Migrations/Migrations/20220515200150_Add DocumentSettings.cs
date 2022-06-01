using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPixel.Migrations.Migrations
{
    public partial class AddDocumentSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Ware");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ware");

            migrationBuilder.CreateTable(
                name: "DocumentSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    WareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ware_DocumentSettings",
                        column: x => x.WareId,
                        principalTable: "Ware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSettings_WareId",
                table: "DocumentSettings",
                column: "WareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentSettings");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Ware",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Ware",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
