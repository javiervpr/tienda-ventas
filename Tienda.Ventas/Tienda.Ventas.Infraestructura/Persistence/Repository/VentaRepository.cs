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

        public async Task<List<VentaDTO>> GetHistorialVentas(Guid clienteID)
        {
            List<VentaDTO> ventaDTOs = new List<VentaDTO>();
            List<Venta> listaVentas =
                await _context.Ventas.Include(x => x.Cliente).Where(v => v.Cliente.Id.Equals(clienteID)).ToListAsync();
            foreach (Venta venta in listaVentas)
            {
                Factura factura = await _context.Facturas.Include(c => c.Venta)
                    .Where(f => f.Venta.Id.Equals(venta.Id)).FirstOrDefaultAsync();
                List<DetalleVentaDTO> detalle = await _context.DetalleVentas.Include(x => x.Venta)
                    .Where(d => d.Venta.Id.Equals(venta.Id))
                    .Select(x => new DetalleVentaDTO
                    {
                        Cantidad = x.Cantidad.Value,
                        Precio = x.Precio.Value,
                        Subtotal = x.Subtotal.Value,
                        Producto = new ProductoDTO(x.Producto.Id, x.Producto.Nombre.Value, x.Producto.Precio.Value, x.Producto.UrlImagen, x.Producto.Categoria.Value)
                    })
                    .ToListAsync();

                ventaDTOs.Add(new VentaDTO()
                {
                    Cliente = null,
                    Factura = new FacturaDTO() { 
                        RazonSocial = factura.RazonSocial, NIT = factura.NIT, FechaEmision = factura.FechaEmision
                    },
                    DetalleVenta = detalle
                });
            }
            return ventaDTOs;
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
    }
}
