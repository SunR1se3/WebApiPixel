using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPixel.Migrations.Migrations
{
    public partial class AddDefaultValueOrderHronology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOrder_Employee_EmployeeId",
                table: "EmployeeOrder");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAcceptionOrder",
                table: "OrderHronology",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeOrder",
                table: "EmployeeOrder",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeOrder",
                table: "EmployeeOrder");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAcceptionOrder",
                table: "OrderHronology",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOrder_Employee_EmployeeId",
                table: "EmployeeOrder",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
