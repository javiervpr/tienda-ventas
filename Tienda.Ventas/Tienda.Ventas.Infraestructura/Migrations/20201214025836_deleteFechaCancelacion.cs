using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Ventas.Infraestructura.Migrations
{
    public partial class deleteFechaCancelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaCancelacion",
                table: "Ventas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCancelacion",
                table: "Ventas",
                type: "datetime2",
                nullable: true);
        }
    }
}
