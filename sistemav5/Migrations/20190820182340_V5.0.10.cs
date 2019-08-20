using Microsoft.EntityFrameworkCore.Migrations;

namespace sistemav5.Migrations
{
    public partial class V5010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteIdCliente",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ClienteIdCliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "Produto",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produto",
                newName: "IdProduto");

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Pedido",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteIdCliente",
                table: "Pedido",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteIdCliente",
                table: "Pedido",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
