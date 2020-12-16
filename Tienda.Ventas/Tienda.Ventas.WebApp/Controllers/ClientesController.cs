using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Features.Cliente.LoginCliente;
using Tienda.Ventas.Applicacion.Features.Cliente.RegistroCliente;

namespace Tienda.Ventas.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ILogger<ClientesController> _logger;

        public ClientesController(IMediator mediator, ILogger<ClientesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Metodo HTTP usado para registrar clientes
        /// </summary>
        /// <param name="registroClienteCommand"></param>
        /// <returns>Retorna un string success y statusCode 200 si es correcta</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Registrar([FromBody] RegistroClienteCommand registroClienteCommand)
        {
            try
            {
                _logger.LogInformation("Registrando cliente con los parametros", registroClienteCommand);
                ClienteDTO clienteDTO = await _mediator.Send(registroClienteCommand);
                return Ok(clienteDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar al cliente con los parametros", registroClienteCommand);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Metodo HTTP para hacer Login
        /// </summary>
        /// <param name="loginClienteQuery"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginClienteQuery loginClienteQuery)
        {
            try
            {
                _logger.LogInformation("Login con el email", loginClienteQuery.Email);
                ClienteDTO clienteDTO = await _mediator.Send(loginClienteQuery);
                if (clienteDTO == null)
                    return NotFound("Usuario/Email incorrectos");
                return Ok(clienteDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar hacer login con el Email", loginClienteQuery.Email);
                return BadRequest(ex.Message);
            }
        }
    }
}