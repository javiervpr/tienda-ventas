using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Applicacion.DTO;

namespace Tienda.Ventas.Applicacion.Features.Venta.GetHistorialVentaByUsuarioID
{
    public class GetHistorialVentaByClienteQuery : IRequest<List<VentaDTO>>
    {
        public Guid ClienteId { get; set; }

        public GetHistorialVentaByClienteQuery(Guid usuarioId)
        {
            ClienteId = usuarioId;
        }
    }
}
