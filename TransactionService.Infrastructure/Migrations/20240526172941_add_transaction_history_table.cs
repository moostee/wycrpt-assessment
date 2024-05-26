using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionService.Infrastructure.Migrations
{
    public partial class add_transaction_history_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SenderAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReceiverAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TransactionHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Network = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_SenderAddress_ReceiverAddress_Currency_Amount_BlockNumber",
                schema: "dbo",
                table: "TransactionHistory",
                columns: new[] { "SenderAddress", "ReceiverAddress", "Currency", "Amount", "BlockNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionHistory",
                schema: "dbo");
        }
    }
}
