using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Ventas.Infraestructura.Migrations
{
    public partial class ClienteEmailAndPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Clientes");
        }
    }
}
