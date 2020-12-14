using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Ventas.Infraestructura.Migrations
{
    public partial class urlImagenAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "urlImagen",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "urlImagen",
                table: "Productos");
        }
    }
}
