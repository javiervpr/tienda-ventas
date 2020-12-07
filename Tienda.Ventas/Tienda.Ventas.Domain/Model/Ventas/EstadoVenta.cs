using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Ventas.Domain.Model.Ventas
{
    public enum EstadoVenta
    {
        Creada = 1,
        Pagada = 2,
        Cancelada = -1,
        Anulada = -2
    }
}
