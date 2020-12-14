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

        public async Task Insert(VentaDTO ventaDTO)
        {
            Cliente cliente = await _context.Clientes.Where(c => c.Id.Equals(ventaDTO.Cliente.Id)).FirstOrDefaultAsync();
            Venta venta = new Venta(cliente, ventaDTO.Factura.RazonSocial, ventaDTO.Factura.NIT);
            
            await _context.Ventas.AddAsync(venta);
            await _context.Facturas.AddAsync(venta.Factura);

            foreach (DetalleVentaDTO detalle in ventaDTO.DetalleVenta)
            {
                Producto producto = await _context.Productos.Where(p => p.Id.Equals(detalle.Producto.Id)).FirstOrDefaultAsync();
                DetalleVenta detalleVenta = new DetalleVenta(detalle.Cantidad, venta, producto);
                await _context.DetalleVentas.AddAsync(detalleVenta);
            }
        }
    }
}
