using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.Persistence.Repository;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Infraestructura.Persistence.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllProducto()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetProductoById(Guid productoID)
        {
            return await _context.Productos.Where(p => p.Id.Equals(productoID)).FirstOrDefaultAsync();
        }

        public async Task Insert(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
        }
    }
}
