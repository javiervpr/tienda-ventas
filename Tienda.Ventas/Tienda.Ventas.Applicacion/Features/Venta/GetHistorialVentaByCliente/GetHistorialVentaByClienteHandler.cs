using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Features.Venta.GetHistorialVentaByUsuarioID;
using Tienda.Ventas.Applicacion.Persistence.Repository;
using Tienda.Ventas.Domain.Model.Ventas;
using System.Linq;

namespace Tienda.Ventas.Applicacion.Features.Venta.GetHistorialVentaByUsuario
{
    public class GetHistorialVentaByClienteHandler : IRequestHandler<GetHistorialVentaByClienteQuery, List<VentaDTO>>
    {
        private readonly IVentaRepository _ventaRepository;

        public GetHistorialVentaByClienteHandler(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<List<VentaDTO>> Handle(GetHistorialVentaByClienteQuery request, CancellationToken cancellationToken)
        {
            List<VentaDTO> ventaDTOs = new List<VentaDTO>();
            List<Ventas.Domain.Model.Ventas.Venta> listaVentas = await _ventaRepository.GetVentasByCliente(request.ClienteId);
            foreach (Ventas.Domain.Model.Ventas.Venta venta in listaVentas)
            {
                Ventas.Domain.Model.Ventas.Factura factura = await _ventaRepository.GetFacturaForVenta(venta.Id);
                List<DetalleVenta> detalle = await _ventaRepository.GetDetalleVenta(venta.Id);
                List<DetalleVentaDTO> detalleVentaDTOs = detalle.Select(x => new DetalleVentaDTO
                     {
                         Cantidad = x.Cantidad.Value,
                         Precio = x.Precio.Value,
                         Subtotal = x.Subtotal.Value,
                         Producto = new ProductoDTO(x.Producto.Id, x.Producto.Nombre.Value, x.Producto.Precio.Value, x.Producto.UrlImagen, x.Producto.Categoria.Value)
                })
                    .ToList();

                ventaDTOs.Add(new VentaDTO()
                {
                    Factura = new FacturaDTO()
                    {
                        RazonSocial = factura.RazonSocial,
                        NIT = factura.NIT,
                        FechaEmision = factura.FechaEmision
                    },
                    DetalleVenta = detalleVentaDTOs
                });
            }
            return ventaDTOs;
        }
    }
}
