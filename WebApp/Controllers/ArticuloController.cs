using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;

namespace WebApp.Controllers
{
    public class ArticuloController : Controller
    {

        IAlta<ArticuloDto> _altaArticulo;
        //IEditar<Articulo> _editarArticulo;
        //IEliminar<Articulo> _eliminarArticulo;
        //IObtener<Articulo> _obtenerArticulo;
        IObtenerTodos<ArticuloDto> _obtenerArticulos;

        public ArticuloController(
            IAlta<ArticuloDto> altaArticulo,
            //IEditar<Articulo> editarArticulo,
            //IEliminar<Articulo> eliminarArticulo,
            //IObtener<Articulo> obtenerArticulo,
            IObtenerTodos<ArticuloDto> obtenerArticulos
            )
        {
            _altaArticulo = altaArticulo;
            //_editarArticulo = editarArticulo;
            //_eliminarArticulo = eliminarArticulo;
            //_obtenerArticulo = obtenerArticulo;
            _obtenerArticulos = obtenerArticulos;
        }

        // GET: ArticuloController
        [AdminAutorizado]
        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View(_obtenerArticulos.Ejecutar());
        }

        // GET: ArticuloController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        [AdminAutorizado]
        // GET: ArticuloController/Create
        public IActionResult Create()
        {
            return View();
        }

        [AdminAutorizado]
        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticuloDto articuloDto)
        {
            try
            {
                _altaArticulo.Ejecutar(articuloDto);
                return RedirectToAction("Index", new { mensaje = "Alta de artículo exitosa." });
            }
            catch (NombreArticuloInvalidaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (DescripcionArticuloInvalidaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (CodigoArticuloInvalidaException e) 
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (NombreRepetidoRepositorioException e) 
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (CodigoRepetidoRepositorioException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (PrecioArticuloInvalidaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (StockArticuloInvalidaException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (ArgumentNullRepositorioException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Hubo un error al crear el artículo. Por favor, intente nuevamente.";
            }

            return View(articuloDto);
        }

        // GET: ArticuloController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: ArticuloController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ArticuloController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ArticuloController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
