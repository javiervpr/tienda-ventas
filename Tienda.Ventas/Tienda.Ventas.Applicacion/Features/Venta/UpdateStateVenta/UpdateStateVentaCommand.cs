using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Applicacion.Features.Venta.UpdateStateVenta
{
    public class UpdateStateVentaCommand : IRequest<VoidResult>
    {
        public Guid VentaID { get; set; }
        public EstadoVenta NewEstado { get; set; }

        public UpdateStateVentaCommand() { }

        public UpdateStateVentaCommand(Guid ventaID, EstadoVenta newEstado)
        {
            VentaID = ventaID;
            NewEstado = newEstado;
        }
    }
}
