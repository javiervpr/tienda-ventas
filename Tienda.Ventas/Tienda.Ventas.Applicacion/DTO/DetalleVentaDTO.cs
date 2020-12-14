using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Ventas.Applicacion.DTO
{
    public class DetalleVentaDTO
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public ProductoDTO Producto { get; set; }
        public double Precio { get; set; }

        public DetalleVentaDTO() { }

        public DetalleVentaDTO(Guid id, int cantidad, double subtotal, ProductoDTO producto, double precio)
        {
            Id = id;
            Cantidad = cantidad;
            Subtotal = subtotal;
            Producto = producto;
            Precio = precio;
        }
    }
}
