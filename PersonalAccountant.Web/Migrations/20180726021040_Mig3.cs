using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalAccountant.Web.Migrations
{
    public partial class Mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ExpenseCategoryID = table.Column<Guid>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExpenseHistory_ExpenseCategory_ExpenseCategoryID",
                        column: x => x.ExpenseCategoryID,
                        principalTable: "ExpenseCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IncomeCategoryID = table.Column<Guid>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IncomeHistory_IncomeCategory_IncomeCategoryID",
                        column: x => x.IncomeCategoryID,
                        principalTable: "IncomeCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseHistory_ExpenseCategoryID",
                table: "ExpenseHistory",
                column: "ExpenseCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeHistory_IncomeCategoryID",
                table: "IncomeHistory",
                column: "IncomeCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseHistory");

            migrationBuilder.DropTable(
                name: "IncomeHistory");
        }
    }
}
