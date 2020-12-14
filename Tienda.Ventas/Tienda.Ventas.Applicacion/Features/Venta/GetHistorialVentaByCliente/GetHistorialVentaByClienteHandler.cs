using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Features.Venta.GetHistorialVentaByUsuarioID;
using Tienda.Ventas.Applicacion.Persistence.Repository;

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
            return await _ventaRepository.GetHistorialVentas(request.ClienteId);
        }
    }
}
