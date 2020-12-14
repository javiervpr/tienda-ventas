using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Ventas.Domain.Model.Ventas.Rules
{
    public class ChangeVentaStatusRule : IBusinessRule
    {
        private readonly EstadoVenta oldStatus;
        private readonly EstadoVenta newStatus;

        public ChangeVentaStatusRule(EstadoVenta oldStatus, EstadoVenta newStatus)
        {
            this.oldStatus = oldStatus;
            this.newStatus = newStatus;
        }

        public string Message => "No se puede cambiar del estado " + oldStatus.ToString() +
            " al estado " + newStatus.ToString();

        public bool IsBroken()
        {
            if (newStatus == EstadoVenta.Anulada && oldStatus != EstadoVenta.Pagada)
                return true;

            if (newStatus == EstadoVenta.Finalizada && oldStatus != EstadoVenta.Pagada)
                return true;

            if (newStatus == EstadoVenta.Pagada &&
                (oldStatus == EstadoVenta.Finalizada || oldStatus == EstadoVenta.Anulada))
                return true;

            return false;
        }
    }
}
