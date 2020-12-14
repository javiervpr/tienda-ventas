using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tienda.Ventas.Applicacion.DTO;
using Tienda.Ventas.Applicacion.Features.Producto.GetAllProductos;
using Tienda.Ventas.Applicacion.Features.Producto.GetProductoById;
using Tienda.Ventas.Applicacion.Features.Producto.InsertProducto;

namespace Tienda.Ventas.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private ILogger<ProductosController> _logger;
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator, ILogger<ProductosController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna una lista de productos
        /// </summary>
        /// <returns>Lista<ProductosDTO></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                _logger.LogInformation("Obteniendo productos...");
                List<ProductoDTO> list = await _mediator.Send(new GetAllProductosQuery());

                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los productos");
            }
            return BadRequest("Ocurrio un error al obtener los productos, intentalo de nuevo más tarde.");
        }

        /// <summary>
        /// Retorna un producto filtrado por su ID
        /// </summary>
        /// <param name="productoID">Tipo String</param>
        /// <returns>productoDTO</returns>
        [HttpGet]
        [Route("{productoID}")]
        public async Task<IActionResult> GetProductoById(string productoID)
        {
            try
            {
                _logger.LogInformation("Obteniendo producto con ID ", productoID);
                ProductoDTO productoDTO = await _mediator.Send(new GetProductoByIdQuery(Guid.Parse(productoID)));
                return Ok(productoDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el producto con ID", productoID);
            }
            return BadRequest("Ocurrio un error al obtener el producto, intentalo de nuevo más tarde.");
        }

        /// <summary>
        /// Metodo HTTP para registrar un producto
        /// </summary>
        /// <param name="productoCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> InsertProducto([FromBody] InsertProductoCommand productoCommand)
        {
            try
            {
                _logger.LogInformation("Insertando producto con los parametros", productoCommand);
                await _mediator.Send(productoCommand);
                return Ok("success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar el producto con los parametros", productoCommand);
            }
            return BadRequest("Ocurrio un error al registrar el producto, intentalo de nuevo más tarde.");
        }
    }
}