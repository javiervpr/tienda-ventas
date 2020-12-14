using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tienda.Ventas.Applicacion.Features.Venta.InsertVenta;

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
    }
}