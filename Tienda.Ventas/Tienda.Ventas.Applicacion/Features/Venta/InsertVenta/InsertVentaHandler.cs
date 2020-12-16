using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Persistence;
using Tienda.Ventas.Applicacion.Persistence.Repository;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Applicacion.Features.Venta.InsertVenta
{
    public class InsertVentaHandler : IRequestHandler<InsertVentaCommand, VoidResult>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertVentaHandler(IVentaRepository ventaRepository, IUnitOfWork unitOfWork)
        {
            _ventaRepository = ventaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(InsertVentaCommand request, CancellationToken cancellationToken)
        {
            Ventas.Domain.Model.Ventas.Cliente cliente = await _ventaRepository.GetClienteForVenta(Guid.Parse(request.ClienteID));
            Ventas.Domain.Model.Ventas.Venta venta = new Domain.Model.Ventas.Venta(cliente, request.Factura.RazonSocial, request.Factura.NIT);
            List<DetalleVenta> detalleVenta = new List<DetalleVenta>();
            foreach (DetalleVentaDTO detalleVentaDTO in request.DetalleVenta)
            {
                Ventas.Domain.Model.Ventas.Producto producto = await _ventaRepository.GetProductoForVenta(detalleVentaDTO.Producto.Id);
                DetalleVenta detalle = new DetalleVenta(detalleVentaDTO.Cantidad, venta, producto);
                detalleVenta.Add(detalle);
            }

            venta.AgregarDetalleVenta(detalleVenta);
            await _ventaRepository.Insert(venta);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }
    }
}
