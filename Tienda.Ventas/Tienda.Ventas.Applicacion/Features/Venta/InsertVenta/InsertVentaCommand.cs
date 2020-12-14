using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Applicacion.DTO;

namespace Tienda.Ventas.Applicacion.Features.Venta.InsertVenta
{
    public class InsertVentaCommand : IRequest<VoidResult>
    {
        public string ClienteID { get; set; }
        public FacturaDTO Factura { get; set; }
        public List<DetalleVentaDTO> DetalleVenta { get; set; }

        public InsertVentaCommand() { }


    }
}
