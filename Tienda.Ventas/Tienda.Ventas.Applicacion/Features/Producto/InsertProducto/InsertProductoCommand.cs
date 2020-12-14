using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Ventas.Applicacion.Features.Producto.InsertProducto
{
    public class InsertProductoCommand : IRequest<VoidResult>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public InsertProductoCommand() { }
    }
}
