using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        IAlta<UsuarioDto> _altaUsuario;
        IEditar<UsuarioDto> _editarUsuario;
        IEliminar<Usuario> _eliminarUsuario;
        IObtener<UsuarioDto> _obtenerUsuario;
        IObtenerTodos<UsuarioDto> _obtenerUsuarios;

        public UsuarioController(
            IAlta<UsuarioDto> altaUsuario, IEditar<UsuarioDto> editarUsuario, IEliminar<Usuario> eliminarUsuario,IObtener<UsuarioDto> obtenerUsuario ,IObtenerTodos<UsuarioDto> obtenerTodos)
        {
            _altaUsuario = altaUsuario;
            _editarUsuario = editarUsuario;
            _eliminarUsuario = eliminarUsuario;
            _obtenerUsuario = obtenerUsuario;
            _obtenerUsuarios = obtenerTodos;
        }

                // GET: UsuarioController
        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View(_obtenerUsuarios.Ejecutar());
        }

        // GET: UsuarioController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: UsuarioController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioDto usuarioDto)//TODO Ver DTOs
        {
            try
            {
                _altaUsuario.Ejecutar(usuarioDto);
                return RedirectToAction("Index", new { mensaje = "Usuario creado exitosamente." }); //TODO recibir en view.
            }
            catch (ContraseniaUsuarioInvalidaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (MailUsuarioInvalidaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Hubo un error al crear usuario. Intente nuevamente.";
            }

            return View(usuarioDto);
        }

        // GET: UsuarioController/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            UsuarioDto usuarioDto = _obtenerUsuario.Ejecutar(id);

            if (usuarioDto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró " + id });
            }

            
            return View(usuarioDto);

        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UsuarioDto usuarioDto)
        {
            try
            {
                _editarUsuario.Ejecutar(id, usuarioDto);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }
        }

        // GET: UsuarioController/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            UsuarioDto usuarioDto = _obtenerUsuario.Ejecutar(id);

            if (usuarioDto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró " + id });
            }
            return View(usuarioDto);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(UsuarioDto usuarioDto)
        {
            try
            {
                _eliminarUsuario.Ejecutar(usuarioDto.Id);
                return RedirectToAction("Index");
            }
            catch (NotFoundException e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = "No se puedo dar de baja. Intente nuevamente." });
            }
        }
    }
}
