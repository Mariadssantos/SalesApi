using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcusDesafio.Migrations
{
    public partial class clientandsale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Sales",
                newName: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientId",
                table: "Sales",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ClientId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Sales",
                newName: "IdClient");
        }
    }
}
