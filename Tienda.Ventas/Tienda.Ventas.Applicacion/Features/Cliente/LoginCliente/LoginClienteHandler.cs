using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Persistence;
using Tienda.Ventas.Applicacion.Persistence.Repository;

namespace Tienda.Ventas.Applicacion.Features.Cliente.LoginCliente
{
    public class LoginClienteHandler : IRequestHandler<LoginClienteQuery, ClienteDTO>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LoginClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ClienteDTO> Handle(LoginClienteQuery request, CancellationToken cancellationToken)
        {
            Ventas.Domain.Model.Ventas.Cliente cliente = await _clienteRepository.Login(request.Email, request.Password);
            if (cliente == null)
                return null;
            ClienteDTO clienteDTO = new ClienteDTO()
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                Email = cliente.Email
            };
            return clienteDTO;
        }

    }
}
