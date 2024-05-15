using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class UsuarioController(
        IAlta<AdminDto> altaUsuario, IEditar<UsuarioDto> editarUsuario, IEliminar<Usuario> eliminarUsuario, IObtener<UsuarioDto> obtenerUsuario, IObtenerTodos<UsuarioDto> obtenerTodos, IObtenerPorDosString<Usuario> obtenerUsuarioPorDosString) : Controller
    {
        IAlta<AdminDto> _altaUsuario = altaUsuario;
        IEditar<UsuarioDto> _editarUsuario = editarUsuario;
        IEliminar<Usuario> _eliminarUsuario = eliminarUsuario;
        IObtener<UsuarioDto> _obtenerUsuario = obtenerUsuario;
        IObtenerTodos<UsuarioDto> _obtenerUsuarios = obtenerTodos;
        IObtenerPorDosString<Usuario> _obtenerUsuarioPorDosString = obtenerUsuarioPorDosString;

        [AdminAutorizado]
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

        [AdminAutorizado]
        // GET: UsuarioController/Create
        public IActionResult Create()
        {
            return View();
        }

        [AdminAutorizado]
        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdminDto adminDto)//TODO Ver DTOs
        {
            try
            {
                _altaUsuario.Ejecutar(adminDto);
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
                ViewBag.Mensaje = e.Message;
            }

            return View(adminDto);
        }

        [AdminAutorizado]
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

        [AdminAutorizado]
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

        [AdminAutorizado]
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

        [AdminAutorizado]
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Mail, string Contrasenia)
        {
            string contraEncriptada = EncodeStringToBase64(Contrasenia);
            
            try
            {
                Usuario unUsuario = _obtenerUsuarioPorDosString.Ejecutar(Mail, contraEncriptada);

                if (unUsuario is Administrador)
                {
                    HttpContext.Session.SetString("Rol", "Administrador");
                    HttpContext.Session.SetString("Nombre", unUsuario.NombreCompleto.Nombre);

                    return RedirectToAction("Index");
                }
            }
            catch (UsuarioNullException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }

            return View();

        }

        public string EncodeStringToBase64(string stringToEncode)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(stringToEncode));
        }

        [AdminAutorizado]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Usuario");
        }
    }
}
