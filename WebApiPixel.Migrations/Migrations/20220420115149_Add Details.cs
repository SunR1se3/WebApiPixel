using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPixel.Migrations.Migrations
{
    public partial class AddDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Ware",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Ware");
        }
    }
}
