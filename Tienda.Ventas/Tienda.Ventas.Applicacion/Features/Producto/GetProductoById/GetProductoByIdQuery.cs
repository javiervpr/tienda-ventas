using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Applicacion.DTO;

namespace Tienda.Ventas.Applicacion.Features.Producto.GetProductoById
{
    public class GetProductoByIdQuery : IRequest<ProductoDTO>
    {
        public Guid Id { get; set; }

        public GetProductoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
