using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Applicacion.DTO;

namespace Tienda.Ventas.Applicacion.Features.Cliente.RegistroCliente
{
    public class RegistroClienteCommand : IRequest<ClienteDTO>
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegistroClienteCommand() { }
    }
}
