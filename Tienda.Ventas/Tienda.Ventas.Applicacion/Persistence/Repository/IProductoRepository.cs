using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Applicacion.Persistence.Repository
{
    public interface IProductoRepository
    {
        Task Insert(Producto producto);
        Task<Producto> GetProductoById(Guid productoID);
        Task<List<Producto>> GetAllProducto();
    }
}
