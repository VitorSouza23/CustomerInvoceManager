using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerInvoiceManager.Repository.Migrations
{
    public partial class AddCustomerInContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerID",
                table: "Contracts");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerID",
                table: "Contracts",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerID",
                table: "Contracts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerID",
                table: "Contracts");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerID",
                table: "Contracts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerID",
                table: "Contracts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
