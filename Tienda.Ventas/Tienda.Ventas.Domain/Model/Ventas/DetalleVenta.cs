using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.ValueObjects;

namespace Tienda.Ventas.Domain.Model.Ventas
{
    public class DetalleVenta: Entity
    {
        public Guid Id { get; private set; }
        public NumMayorACeroValue Cantidad { get; private set; }
        public DoubleMayorIgualACeroValue Subtotal { get; private set; }
        public Venta Venta { get; private set; }
        public Producto Producto { get; private set; }
        public DoubleMayorIgualACeroValue Precio { get; private set; }

        public DetalleVenta(int cantidad, Venta venta, Producto producto)
        {
            Id = Guid.NewGuid();
            Cantidad = cantidad;
            Venta = venta;
            Producto = producto;
            Precio = producto.Precio.Value;
            Subtotal = cantidad * producto.Precio.Value;
        }

        protected DetalleVenta () { }
    }
}
