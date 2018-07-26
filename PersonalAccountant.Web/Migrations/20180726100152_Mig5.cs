using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalAccountant.Web.Migrations
{
    public partial class Mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountsID",
                table: "IncomeHistory",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountsID",
                table: "ExpenseHistory",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_IncomeHistory_AccountsID",
                table: "IncomeHistory",
                column: "AccountsID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseHistory_AccountsID",
                table: "ExpenseHistory",
                column: "AccountsID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistory_Accounts_AccountsID",
                table: "ExpenseHistory",
                column: "AccountsID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeHistory_Accounts_AccountsID",
                table: "IncomeHistory",
                column: "AccountsID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistory_Accounts_AccountsID",
                table: "ExpenseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistory_Accounts_AccountsID",
                table: "IncomeHistory");

            migrationBuilder.DropIndex(
                name: "IX_IncomeHistory_AccountsID",
                table: "IncomeHistory");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseHistory_AccountsID",
                table: "ExpenseHistory");

            migrationBuilder.DropColumn(
                name: "AccountsID",
                table: "IncomeHistory");

            migrationBuilder.DropColumn(
                name: "AccountsID",
                table: "ExpenseHistory");
        }
    }
}
