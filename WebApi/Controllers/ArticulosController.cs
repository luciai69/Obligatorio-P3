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
    public class ArticulosController : ControllerBase
    {
       
        IObtenerTodos<ArticuloDto> _obtenerArticulos;

        public ArticulosController(
       
            IObtenerTodos<ArticuloDto> obtenerArticulos
            )
        {
            _obtenerArticulos = obtenerArticulos;
        }

        // GET: ArticuloController

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_obtenerArticulos.Ejecutar());
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
