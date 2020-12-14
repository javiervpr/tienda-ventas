using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.Persistence;
using Tienda.Ventas.Applicacion.Persistence.Repository;

namespace Tienda.Ventas.Applicacion.Features.Venta.UpdateStateVenta
{
    public class UpdateStateVentaHandler : IRequestHandler<UpdateStateVentaCommand, VoidResult>
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStateVentaHandler(IVentaRepository ventaRepository, IUnitOfWork unitOfWork)
        {
            _ventaRepository = ventaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(UpdateStateVentaCommand request, CancellationToken cancellationToken)
        {
            await _ventaRepository.UpdateState(request.VentaID, request.NewEstado);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }
    }
}
