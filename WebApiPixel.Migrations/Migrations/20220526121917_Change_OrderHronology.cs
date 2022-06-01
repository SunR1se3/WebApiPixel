using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPixel.Migrations.Migrations
{
    public partial class Change_OrderHronology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOrderIsReady",
                table: "OrderHronology");

            migrationBuilder.DropColumn(
                name: "DatePrepare",
                table: "OrderHronology");

            migrationBuilder.DropColumn(
                name: "DateProduce",
                table: "OrderHronology");

            migrationBuilder.AddColumn<bool>(
                name: "Production",
                table: "OrderHronology",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "OrderHronology",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Production",
                table: "OrderHronology");

            migrationBuilder.DropColumn(
                name: "isDone",
                table: "OrderHronology");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOrderIsReady",
                table: "OrderHronology",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePrepare",
                table: "OrderHronology",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateProduce",
                table: "OrderHronology",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
