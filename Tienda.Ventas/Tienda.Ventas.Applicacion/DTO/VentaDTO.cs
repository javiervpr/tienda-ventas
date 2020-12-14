using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Ventas.Applicacion.DTO
{
    public class VentaDTO
    {
        public ClienteDTO Cliente { get; set; }
        public FacturaDTO Factura { get; set; }
        public List<DetalleVentaDTO> DetalleVenta { get; set; }

        public VentaDTO() { }
        public VentaDTO(ClienteDTO cliente, FacturaDTO factura, List<DetalleVentaDTO> detalleVenta)
        {
            Cliente = cliente;
            Factura = factura;
            DetalleVenta = detalleVenta;
        }
    }
}
