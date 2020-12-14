using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Applicacion.DTO;

namespace Tienda.Ventas.Applicacion.Features.Producto.GetAllProductos
{
    public class GetAllProductosQuery : IRequest<List<ProductoDTO>>
    {
    }
}
