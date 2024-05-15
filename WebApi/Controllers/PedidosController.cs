using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        IObtenerPorBool<PedidoDto>  _obtenerPedidosPorAnulado;

        public PedidosController(

            IObtenerPorBool<PedidoDto> obtenerPedidosPorAnulado
            )
        {
            _obtenerPedidosPorAnulado = obtenerPedidosPorAnulado;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetByBool()
        {
            try
            {
                IEnumerable<PedidoDto> listaPedidos = _obtenerPedidosPorAnulado.Ejecutar(true);
                return Ok(listaPedidos);
            }
            //catch (NotFoundException e)
            //{
            //    return StatusCode(StatusCodes.Status204NoContent);
            //}
            catch (Exception e)
            {
                return StatusCode(500, "Hupp" + e.Message);
            }

        }

    }
}
