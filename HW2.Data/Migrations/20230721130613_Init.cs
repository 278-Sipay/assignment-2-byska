using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW2.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false, defaultValue: 0m),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false, defaultValue: 0m),
                    DebitAmount = table.Column<decimal>(type: "decimal(15,4)", maxLength: 0, precision: 15, scale: 4, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Account",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountNumber", "Balance", "CurrencyCode", "InsertDate", "InsertUser", "IsActive", "Name", "OpenDate" },
                values: new object[] { 10001, 1500m, "TRY", new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SystemAdmin", true, "John", new DateTime(2010, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountNumber", "Balance", "CurrencyCode", "InsertDate", "InsertUser", "IsActive", "Name", "OpenDate" },
                values: new object[] { 10002, 2500m, "TRY", new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SystemAdmin", true, "Jeyn", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountNumber", "Balance", "CurrencyCode", "InsertDate", "InsertUser", "IsActive", "Name", "OpenDate" },
                values: new object[] { 10003, 5200m, "TRY", new DateTime(2023, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SystemAdmin", true, "Tom", new DateTime(2020, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountNumber", "CreditAmount", "DebitAmount", "Description", "InsertDate", "InsertUser", "ReferenceNumber", "TransactionDate" },
                values: new object[] { 1, 10001, 10000m, 20000m, "EFT", new DateTime(2019, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "20020", new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountNumber", "CreditAmount", "DebitAmount", "Description", "InsertDate", "InsertUser", "ReferenceNumber", "TransactionDate" },
                values: new object[] { 2, 10001, 5000m, 25000m, "EFT", new DateTime(2019, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "20050", new DateTime(2021, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountNumber", "CreditAmount", "DebitAmount", "Description", "InsertDate", "InsertUser", "ReferenceNumber", "TransactionDate" },
                values: new object[] { 3, 10002, 12000m, 10000m, "EFT", new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "20150", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountNumber",
                table: "Account",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountNumber",
                table: "Transaction",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReferenceNumber",
                table: "Transaction",
                column: "ReferenceNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
