using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Ventas.Applicacion.DTO
{
    public class FacturaDTO
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string NIT { get; set; }

        public DateTime FechaEmision { get; set; }

        public FacturaDTO() { }

        public FacturaDTO(Guid id, string razonSocial, string nIT, DateTime fechaEmision)
        {
            Id = id;
            RazonSocial = razonSocial;
            NIT = nIT;
            FechaEmision = fechaEmision;
        }
    }
}
