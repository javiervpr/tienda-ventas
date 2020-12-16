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
        Task Insert(Venta venta);

        Task<List<Venta>> GetVentasByCliente (Guid clienteID);
        Task<List<DetalleVenta>> GetDetalleVenta(Guid ventaID);
        Task<Factura> GetFacturaForVenta(Guid ventaID);
        Task UpdateState(Guid ventaID, EstadoVenta newEstado);

        Task<Cliente> GetClienteForVenta(Guid clienteID);
        Task<Producto> GetProductoForVenta(Guid productoID);
    }
}
