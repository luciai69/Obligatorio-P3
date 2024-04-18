using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class ClienteController(IObtenerTodos<Cliente> obtenerTodos, IObtenerPorString<Cliente> obtenerPorString, IObtenerPorInt<Cliente> obtenerPorInt) : Controller
    {
        IObtenerTodos<Cliente> _obtenerClientes = obtenerTodos;
        IObtenerPorString<Cliente> _obtenerPorString = obtenerPorString;
        IObtenerPorInt<Cliente> _obtenerPorInt = obtenerPorInt;

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

        public IActionResult ObtenerPorMonto(int monto)
        {
            return View("Index", _obtenerPorInt.Ejecutar(monto));
        }
    }
}
