using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Applicacion.Persistence.Repository
{
    public interface IClienteRepository
    {
        Task Registrar(Cliente cliente);
        Task<Cliente> Login(string email, string password);
    }
}
