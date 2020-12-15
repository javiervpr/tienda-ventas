using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Persistence.Repository;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Infraestructura.Persistence.Repository
{
    public class VentaRepository : IVentaRepository
    {
        private readonly ApplicationDbContext _context;

        public VentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Insert(Venta venta)
        {
            await _context.Ventas.AddAsync(venta);
            await _context.Facturas.AddAsync(venta.Factura);
            foreach (DetalleVenta detalleVenta in venta.DetalleVenta)
            {
                await _context.DetalleVentas.AddAsync(detalleVenta);
            }
        }

        public async Task UpdateState(Guid ventaID, EstadoVenta newEstado)
        {
            Venta venta = await _context.Ventas.Where(v => v.Id.Equals(ventaID)).FirstOrDefaultAsync();
            switch (newEstado)
            {
                case EstadoVenta.Finalizada:
                    venta.FinalizarVenta();
                    break;
                case EstadoVenta.Anulada:
                    venta.AnularVenta();
                    break;
            }
        }

        public async Task<Cliente> GetClienteForVenta(Guid clienteID)
        {
            return await _context.Clientes.Where(c => c.Id.Equals(clienteID)).FirstOrDefaultAsync();
        }

        public async Task<Producto> GetProductoForVenta(Guid productoID)
        {
            return await _context.Productos.Where(c => c.Id.Equals(productoID)).FirstOrDefaultAsync();
        }

        public async Task<List<Venta>> GetVentasByCliente(Guid clienteID)
        {
            return await _context.Ventas.Include(x => x.Cliente)
                .Where(v => v.Cliente.Id.Equals(clienteID)).ToListAsync();
        }

        public async Task<List<DetalleVenta>> GetDetalleVenta(Guid ventaID)
        {
            return await _context.DetalleVentas.Include(x => x.Venta).Include(p => p.Producto)
                    .Where(d => d.Venta.Id.Equals(ventaID)).ToListAsync();
        }

        public async Task<Factura> GetFacturaForVenta(Guid ventaID)
        {
            return await _context.Facturas.Include(c => c.Venta)
                    .Where(f => f.Venta.Id.Equals(ventaID)).FirstOrDefaultAsync();
        }
    }
}
