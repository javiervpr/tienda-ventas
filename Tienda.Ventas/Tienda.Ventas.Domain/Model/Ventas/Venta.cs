using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Ventas.Domain.Model.Ventas
{
    public class Venta: Entity
    {
        public Guid Id { get; private set; }
        public EstadoVenta EstadoVenta { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaFinalizacion { get; private set; }
        public DateTime? FechaCancelacion { get; private set; }
        public DateTime? FechaAnulacion { get; private set; }

        private Factura _factura;
        private List<DetalleVenta> _listaDetalles;


        public ImmutableList<DetalleVenta>

    }
}
