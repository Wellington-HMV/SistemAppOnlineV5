using Microsoft.EntityFrameworkCore.Migrations;

namespace sistemav5.Migrations
{
    public partial class V509 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_ProdutoId",
                table: "ItensPedido",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Produto",
                table: "ItensPedido",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Produto",
                table: "ItensPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedido_ProdutoId",
                table: "ItensPedido");
        }
    }
}
