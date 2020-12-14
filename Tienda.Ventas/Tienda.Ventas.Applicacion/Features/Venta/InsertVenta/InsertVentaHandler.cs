using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Persistence;
using Tienda.Ventas.Applicacion.Persistence.Repository;

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
            ClienteDTO clienteDTO = new ClienteDTO() { Id = Guid.Parse(request.ClienteID) };
            VentaDTO ventaDTO = new VentaDTO()
            {
                Cliente = clienteDTO,
                Factura = request.Factura,
                DetalleVenta = request.DetalleVenta
            };
            await _ventaRepository.Insert(ventaDTO);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }
    }
}
