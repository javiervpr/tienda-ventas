using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Applicacion.Persistence.Repository
{
    public interface IVentaRepository
    {
        Task Insert(VentaDTO venta);

        Task<List<VentaDTO>> GetHistorialVentas(Guid clienteID);

        Task UpdateState(Guid ventaID, EstadoVenta newEstado);
    }
}
