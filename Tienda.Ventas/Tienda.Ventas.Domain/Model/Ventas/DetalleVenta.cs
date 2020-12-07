using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Ventas.Domain.Model.Ventas
{
    public class DetalleVenta: Entity
    {
        public Guid Id { get; private set; }
        public int Cantidad { get; private set; }
        public double Subtotal { get; private set; }
        public Venta Venta { get; private set; }
        public Producto Producto { get; private set; }
        public double Precio { get; private set; }

        public DetalleVenta(int cantidad, double subtotal, Venta venta, Producto producto, double precio)
        {
            Cantidad = cantidad;
            Subtotal = subtotal;
            Venta = venta;
            Producto = producto;
            Precio = precio;
        }

        protected DetalleVenta () { }
    }
}
