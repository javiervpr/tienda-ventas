using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Ventas.Domain.Model.Ventas
{
    public class Factura: Entity
    {
        public Guid Id { get; private set; }
        public string RazonSocial { get; private set; }
        public string NIT { get; private set; }

        public DateTime FechaEmision { get; private set; }
        public Venta Venta { get; private set; }

        protected Factura () { }

        public Factura(string razonSocial, string nit, Venta venta)
        {
            Id = Guid.NewGuid();
            RazonSocial = razonSocial;
            NIT = nit;
            FechaEmision = DateTime.Now;
            Venta = venta;
        }
    }
}
