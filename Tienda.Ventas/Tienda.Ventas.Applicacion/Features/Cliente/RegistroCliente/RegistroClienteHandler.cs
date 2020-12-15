using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Persistence;
using Tienda.Ventas.Applicacion.Persistence.Repository;

namespace Tienda.Ventas.Applicacion.Features.Cliente.RegistroCliente
{
    public class RegistroClienteHandler : IRequestHandler<RegistroClienteCommand, ClienteDTO>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistroClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ClienteDTO> Handle(RegistroClienteCommand request, CancellationToken cancellationToken)
        {
            Ventas.Domain.Model.Ventas.Cliente cliente = new Domain.Model.Ventas.Cliente(request.Nombres, request.Apellidos, request.Email, request.Password);
            await _clienteRepository.Registrar(cliente);
            await _unitOfWork.Commit(cancellationToken);
            ClienteDTO clienteDTO = new ClienteDTO()
            {
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                Email = cliente.Email,
                Id = cliente.Id
            };
            return clienteDTO;
        }
    }
}
