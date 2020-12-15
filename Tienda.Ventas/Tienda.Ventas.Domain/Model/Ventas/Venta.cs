using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.Model.Ventas.Rules;

namespace Tienda.Ventas.Domain.Model.Ventas
{
    public class Venta: Entity
    {
        public Guid Id { get; private set; }
        public EstadoVenta EstadoVenta { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaFinalizacion { get; private set; }
        public DateTime? FechaAnulacion { get; private set; }
        public Factura Factura { get; private set; }
        private List<DetalleVenta> _detalleVenta;
        public ImmutableList<DetalleVenta> DetalleVenta
        {
            get
            {
                return _detalleVenta.ToImmutableList();
            }
        }

        protected Venta() { }

        public Venta(Cliente cliente, string razonSocial, string nit)
        {
            Id = Guid.NewGuid();
            FechaCreacion = DateTime.Now;
            EstadoVenta = EstadoVenta.Pagada;
            Cliente = cliente;
            Factura = new Factura(razonSocial,nit, this);
        }
        public void AgregarDetalleVenta(List<DetalleVenta> detalleVenta)
        {
            _detalleVenta = detalleVenta;
        }
        public void AnularVenta()
        {
            CheckRule(new ChangeVentaStatusRule(EstadoVenta, EstadoVenta.Anulada));
            FechaAnulacion = DateTime.Now;
            EstadoVenta = EstadoVenta.Anulada;
        }

        public void FinalizarVenta()
        {
            CheckRule(new ChangeVentaStatusRule(EstadoVenta, EstadoVenta.Finalizada));
            FechaFinalizacion = DateTime.Now;
            EstadoVenta = EstadoVenta.Finalizada;
        }
    }
}
