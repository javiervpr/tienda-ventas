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
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Verifica los credenciales
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Retorna null en caso de error</returns>
        public async Task<Cliente> Login(string email, string password)
        {
            return await _context.Clientes.Where(c => c.Email.Value.Equals(email) && c.Password.Value.Equals(password)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Registra un nuevo cliente en la DB
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task Registrar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
        }
    }
}
