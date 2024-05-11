using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class ClienteController(IObtenerTodos<ClienteDto> obtenerTodos, IObtenerPorString<ClienteDto> obtenerPorString, IObtenerPorInt<ClienteDto> obtenerPorInt) : Controller
    {
        IObtenerTodos<ClienteDto> _obtenerClientes = obtenerTodos;
        IObtenerPorString<ClienteDto> _obtenerPorString = obtenerPorString;
        IObtenerPorInt<ClienteDto> _obtenerPorInt = obtenerPorInt;

        [AdminAutorizado]
        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View(_obtenerClientes.Ejecutar());
        }

        [AdminAutorizado]
        public IActionResult ObtenerPorRut(string rut)
        {
            return View("Index", _obtenerPorString.Ejecutar(rut));
        }

        [AdminAutorizado]
        public IActionResult ObtenerPorMonto(int monto)
        {
            return View("Index", _obtenerPorInt.Ejecutar(monto));
        }
    }
}
