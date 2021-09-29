using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionMicroservice.Migrations
{
    public partial class initialTransact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counterparties",
                columns: table => new
                {
                    Counterparty_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Counterparty_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other_Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counterparties", x => x.Counterparty_ID);
                });

            migrationBuilder.CreateTable(
                name: "financialTransactions",
                columns: table => new
                {
                    Transaction_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_ID = table.Column<int>(type: "int", nullable: false),
                    Counterparty_ID = table.Column<int>(type: "int", nullable: false),
                    Payment_Method_Code = table.Column<int>(type: "int", nullable: false),
                    Service_ID = table.Column<int>(type: "int", nullable: false),
                    transaction_status_code = table.Column<int>(type: "int", nullable: false),
                    Transaction_type_code = table.Column<int>(type: "int", nullable: false),
                    Date_of_Transaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount_of_Transaction = table.Column<float>(type: "real", nullable: false),
                    Other_Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financialTransactions", x => x.Transaction_ID);
                });

            migrationBuilder.CreateTable(
                name: "RefPaymentMethod",
                columns: table => new
                {
                    Payment_Method_Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_Method_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefPaymentMethod", x => x.Payment_Method_Code);
                });

            migrationBuilder.CreateTable(
                name: "RefTransactionStatuse",
                columns: table => new
                {
                    transaction_status_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_status_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefTransactionStatuse", x => x.transaction_status_code);
                });

            migrationBuilder.CreateTable(
                name: "RefTransactionType",
                columns: table => new
                {
                    Transaction_type_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transaction_type_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefTransactionType", x => x.Transaction_type_code);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    Service_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Service_Provided = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Other_Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.Service_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Counterparties");

            migrationBuilder.DropTable(
                name: "financialTransactions");

            migrationBuilder.DropTable(
                name: "RefPaymentMethod");

            migrationBuilder.DropTable(
                name: "RefTransactionStatuse");

            migrationBuilder.DropTable(
                name: "RefTransactionType");

            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
