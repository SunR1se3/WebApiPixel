using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPixel.Migrations.Migrations
{
    public partial class Add_Employee_Order_EmployeeOrder_OrderHronology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderHronology",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreationOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAcceptionOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePrepare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateProduce = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOrderIsReady = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHronology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderHronology",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeOrder_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_EmployeeOrder",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOrder_EmployeeId",
                table: "EmployeeOrder",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOrder_OrderId",
                table: "EmployeeOrder",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHronology_IdOrder",
                table: "OrderHronology",
                column: "IdOrder",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeOrder");

            migrationBuilder.DropTable(
                name: "OrderHronology");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
