using Microsoft.EntityFrameworkCore.Migrations;

namespace sistemav5.Migrations
{
    public partial class v503 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Pedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);
        }
    }
}
