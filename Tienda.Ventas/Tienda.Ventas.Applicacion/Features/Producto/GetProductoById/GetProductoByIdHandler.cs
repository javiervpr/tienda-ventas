using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Persistence.Repository;

namespace Tienda.Ventas.Applicacion.Features.Producto.GetProductoById
{
    public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, ProductoDTO>
    {
        private readonly IProductoRepository _productoRepository;

        public GetProductoByIdHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<ProductoDTO> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            Ventas.Domain.Model.Ventas.Producto producto = await _productoRepository.GetProductoById(request.Id);
            ProductoDTO productoDTO = new ProductoDTO()
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio
            };
            return productoDTO;
        }
    }
}
