using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Persistence.Repository;

namespace Tienda.Ventas.Applicacion.Features.Producto.GetAllProductos
{
    public class GetAllProductosHandler : IRequestHandler<GetAllProductosQuery, List<ProductoDTO>>
    {
        private readonly IProductoRepository _productoRepository;

        public GetAllProductosHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<List<ProductoDTO>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
        {
            List<Ventas.Domain.Model.Ventas.Producto> listaProductos = await _productoRepository.GetAllProducto();
            List<ProductoDTO> resultingList = new List<ProductoDTO>();
            foreach (var item in listaProductos)
            {
                resultingList.Add(new ProductoDTO()
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                    UrlImagen = item.UrlImagen
                });
            }

            return await Task.Run(() => resultingList);
        }
    }
}
