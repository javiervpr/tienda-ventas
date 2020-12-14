using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Ventas.Applicacion.Features.Cliente.RegistroCliente
{
    public class RegistroClienteCommand : IRequest<VoidResult>
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegistroClienteCommand() { }
    }
}
