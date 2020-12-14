using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Applicacion.DTO;

namespace Tienda.Ventas.Applicacion.Features.Cliente.LoginCliente
{
    public class LoginClienteQuery : IRequest<ClienteDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginClienteQuery() { }

        public LoginClienteQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
