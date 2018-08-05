using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalAccountant.Web.Migrations
{
    public partial class Mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistory_Accounts_AccountsID",
                table: "ExpenseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistory_ExpenseCategory_ExpenseCategoryID",
                table: "ExpenseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistory_Accounts_AccountsID",
                table: "IncomeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistory_IncomeCategory_IncomeCategoryID",
                table: "IncomeHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistory_Accounts_AccountsID",
                table: "ExpenseHistory",
                column: "AccountsID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistory_ExpenseCategory_ExpenseCategoryID",
                table: "ExpenseHistory",
                column: "ExpenseCategoryID",
                principalTable: "ExpenseCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeHistory_Accounts_AccountsID",
                table: "IncomeHistory",
                column: "AccountsID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeHistory_IncomeCategory_IncomeCategoryID",
                table: "IncomeHistory",
                column: "IncomeCategoryID",
                principalTable: "IncomeCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistory_Accounts_AccountsID",
                table: "ExpenseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistory_ExpenseCategory_ExpenseCategoryID",
                table: "ExpenseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistory_Accounts_AccountsID",
                table: "IncomeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeHistory_IncomeCategory_IncomeCategoryID",
                table: "IncomeHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistory_Accounts_AccountsID",
                table: "ExpenseHistory",
                column: "AccountsID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistory_ExpenseCategory_ExpenseCategoryID",
                table: "ExpenseHistory",
                column: "ExpenseCategoryID",
                principalTable: "ExpenseCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeHistory_Accounts_AccountsID",
                table: "IncomeHistory",
                column: "AccountsID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeHistory_IncomeCategory_IncomeCategoryID",
                table: "IncomeHistory",
                column: "IncomeCategoryID",
                principalTable: "IncomeCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
