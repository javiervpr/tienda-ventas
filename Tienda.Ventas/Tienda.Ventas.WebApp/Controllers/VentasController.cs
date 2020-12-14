using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Features.Venta.GetHistorialVentaByUsuarioID;
using Tienda.Ventas.Applicacion.Features.Venta.InsertVenta;
using Tienda.Ventas.Applicacion.Features.Venta.UpdateStateVenta;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ILogger<VentasController> _logger;

        public VentasController(IMediator mediator, ILogger<VentasController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> InsertVenta([FromBody] InsertVentaCommand insertVentaCommand)
        {
            try
            {
                _logger.LogInformation("Insertando venta con los parametros", insertVentaCommand);
                await _mediator.Send(insertVentaCommand);
                return Ok("success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar la venta con los parametros", insertVentaCommand);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("historial/{clienteID}")]
        public async Task<IActionResult> GetHistorialVentaByClienteId(string clienteID)
        {
            try
            {
                _logger.LogInformation("Obteniendo historial de ventas del ID ", clienteID);
                List<VentaDTO> ventaDTOs = await _mediator.Send(new GetHistorialVentaByClienteQuery(Guid.Parse(clienteID)));
                return Ok(ventaDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el historial de venta con ID", clienteID);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("finalizar")]
        public async Task<IActionResult> FinalizarVenta([FromBody] UpdateStateVentaCommand updateStateVentaCommand)
        {
            try
            {
                _logger.LogInformation("Finalizando venta con parametros ->", updateStateVentaCommand);
                updateStateVentaCommand.NewEstado = EstadoVenta.Finalizada;
                await _mediator.Send(updateStateVentaCommand);
                return Ok("success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al finalizar la venta con los parametros", updateStateVentaCommand);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("anular")]
        public async Task<IActionResult> AnularVenta([FromBody] UpdateStateVentaCommand updateStateVentaCommand)
        {
            try
            {
                _logger.LogInformation("Finalizando venta con parametros ->", updateStateVentaCommand);
                updateStateVentaCommand.NewEstado = EstadoVenta.Anulada;
                await _mediator.Send(updateStateVentaCommand);
                return Ok("success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al finalizar la venta con los parametros", updateStateVentaCommand);
                return BadRequest(ex.Message);
            }
        }
    }
}