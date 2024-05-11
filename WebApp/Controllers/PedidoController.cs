using LogicaAplicacion.Articulos;
using LogicaAplicacion.Usuarios;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApp.Controllers
{
    public class PedidoController : Controller
    {
        IObtener<Articulo> _obtenerArticulo;
        IObtener<Cliente> _obtenerCliente;
        IObtenerTodos<ArticuloDto> _obtenerArticulos;
        IObtenerTodos<ClienteDto> _obtenerClientes;
        IAlta<PedidoExpressDto> _altaPedidoExpress;
        IAlta<PedidoComunDto> _altaPedidoComun;
        IObtenerPorFecha<PedidoDto> _obtenerPedidos;
        IAnular<Pedido> _anularPedido;


        public PedidoController(
            IObtener<Articulo> obtenerArticulo,
            IObtener<Cliente> obtenerCliente,
            IObtenerTodos<ArticuloDto> obtenerArticulos,
            IObtenerTodos<ClienteDto> obtenerClientes,
            IAlta<PedidoExpressDto> altaPedidoExpress,
            IAlta<PedidoComunDto> altaPedidoComun,
            IObtenerPorFecha<PedidoDto> obtenerPedidos,
            IAnular<Pedido> anularPedido)
            
        {
            _obtenerArticulo = obtenerArticulo;
            _obtenerCliente = obtenerCliente;
            _obtenerArticulos = obtenerArticulos;
            _obtenerClientes = obtenerClientes;
            _altaPedidoExpress = altaPedidoExpress;
            _altaPedidoComun = altaPedidoComun;
            _obtenerPedidos = obtenerPedidos;
            _anularPedido = anularPedido;
        }


        public IActionResult CatalogoExpress()
        {
            return View(_obtenerArticulos.Ejecutar());
        }

        public IActionResult CatalogoComun()
        {
            return View(_obtenerArticulos.Ejecutar());
        }

        [HttpPost]
        public IActionResult AgregarLineaEx(int idArticulo, int cantidad)
        {
            try
            {
                Articulo articulo = _obtenerArticulo.Ejecutar(idArticulo);

                if (articulo == null)
                {
                    throw new ArticuloPedidoInvalidoException();
                }

                PedidoExpressDto pedidoDto = GetPedidoExFromSession();
                if (pedidoDto == null)
                {
                    throw new PedidoNuloException();
                }

                var linea = new LineaDto()
                {
                    ArticuloId = articulo.Id,
                    Nombre = articulo.Nombre,
                    Descripcion = articulo.Descripcion,
                    Codigo = articulo.Codigo,
                    CantUnidades = cantidad,
                    PrecioUnitarioVigente = articulo.Precio
                };//Esto se puede hacer en un metodo CrearLinea que reciba cant y articulo

                pedidoDto.Lineas.Add(linea); //aca se llama al metodo
                pedidoDto.Cantidad += cantidad;
                pedidoDto.MontoSubtotal += articulo.Precio * cantidad;

                SetViewBagEx(pedidoDto);
                SetPedidoExToSession(pedidoDto);
                ViewBag.Error = false;
                ViewBag.Mensaje = "Se dio de alta con exito";
            }
            catch (Exception e)
            {
                ViewBag.Error = true;
                ViewBag.Mensaje = e.Message;
            }
            return View("CatalogoExpress", _obtenerArticulos.Ejecutar());
        }

        public IActionResult CheckoutEx(int IdCliente, DateTime fechaEntrega)
        {
            Cliente cliente = _obtenerCliente.Ejecutar(IdCliente);

            try
            {
                if (cliente == null)
                {
                    throw new ClientePedidoInvalidaException();
                }
                PedidoExpressDto pedidoExpressDto = GetPedidoExFromSession();

                if (pedidoExpressDto == null)
                {
                    throw new PedidoNuloException();
                }
                pedidoExpressDto.ClienteId = IdCliente;
                pedidoExpressDto.FechaEntrega = fechaEntrega;
                _altaPedidoExpress.Ejecutar(pedidoExpressDto);


                ViewBag.Error = false;
                ViewBag.Mensaje = "Pedido realizado exitosamente.";
            }
            catch (Exception e)
            {
                ViewBag.Error = true;
                ViewBag.Mensaje = e.Message;

            }

            return View("CatalogoComun", _obtenerArticulos.Ejecutar());


        }

        private PedidoExpressDto GetPedidoExFromSession()
        {
            PedidoExpressDto pedidoExpressDtoRecuperado;

            string? json = HttpContext.Session.GetString("SessionCompraDto");
            if (string.IsNullOrEmpty(json))
            {
                pedidoExpressDtoRecuperado = new PedidoExpressDto();
            }
            else
            {
                pedidoExpressDtoRecuperado = JsonSerializer.Deserialize<PedidoExpressDto>(json);
            }
            return pedidoExpressDtoRecuperado;
        }
        
        private void SetPedidoExToSession(PedidoExpressDto pedidoExpressDto)
        {
            HttpContext.Session.SetString("SessionCompraDto", JsonSerializer.Serialize(pedidoExpressDto));
        }

        private void SetViewBagEx(PedidoExpressDto pedidoExpressDto)
        {
            ViewBag.cantidad = pedidoExpressDto.Cantidad;
            ViewBag.total = pedidoExpressDto.MontoSubtotal;
            ViewBag.catalogo = pedidoExpressDto.Lineas;
        }
        

        // PARTE PEDIDOS COMUNES

        [HttpPost]
        public IActionResult AgregarLineaCom(int idArticulo, int cantidad)
        {
            try
            {
                Articulo articulo = _obtenerArticulo.Ejecutar(idArticulo);


                if (articulo == null)
                {
                    throw new ArticuloPedidoInvalidoException();
                }

                PedidoComunDto pedidoDto = GetPedidoComFromSession();
                if (pedidoDto == null)
                {
                    throw new PedidoNuloException();
                }

                var linea = new LineaDto()
                {
                    ArticuloId = articulo.Id,
                    Nombre = articulo.Nombre,
                    Descripcion = articulo.Descripcion,
                    Codigo = articulo.Codigo,
                    CantUnidades = cantidad,
                    PrecioUnitarioVigente = articulo.Precio
                };//Esto se puede hacer en un metodo CrearLinea que reciba cant y articulo

                pedidoDto.Lineas.Add(linea); //aca se llama al metodo
                pedidoDto.Cantidad += cantidad;
                pedidoDto.MontoSubtotal += articulo.Precio * cantidad;

                SetViewBagCom(pedidoDto);
                SetPedidoComToSession(pedidoDto);
                ViewBag.Error = false;
                ViewBag.Mensaje = "Artículo agregado exitosamente";
            }
            catch (Exception e)
            {
                ViewBag.Error = true;
                ViewBag.Mensaje = e.Message;
            }
            return View("CatalogoComun", _obtenerArticulos.Ejecutar());
        }

        

        public IActionResult CheckoutCom(int IdCliente, DateTime fechaEntrega)
        {
            Cliente cliente = _obtenerCliente.Ejecutar(IdCliente);

            try
            {
                if (cliente == null)
                {
                    throw new ClientePedidoInvalidaException();
                }

                PedidoComunDto pedidoComunDto = GetPedidoComFromSession();

                if (pedidoComunDto == null)
                {
                    throw new PedidoNuloException();
                }
                pedidoComunDto.ClienteId = IdCliente;
                pedidoComunDto.FechaEntrega = fechaEntrega;
                _altaPedidoComun.Ejecutar(pedidoComunDto);


                ViewBag.Error = false;
                ViewBag.Mensaje = "Pedido realizado exitosamente.";

            }
            catch (Exception e)
            {
                ViewBag.Error = true;
                ViewBag.Mensaje = e.Message;
            }

            return View("CatalogoComun", _obtenerArticulos.Ejecutar());


        }

        private PedidoComunDto GetPedidoComFromSession()
        {
            PedidoComunDto pedidoComunDtoRecuperado;

            string? json = HttpContext.Session.GetString("SessionCompraDto");
            if (string.IsNullOrEmpty(json))
            {
                pedidoComunDtoRecuperado = new PedidoComunDto();
            }
            else
            {
                pedidoComunDtoRecuperado = JsonSerializer.Deserialize<PedidoComunDto>(json);
            }
            return pedidoComunDtoRecuperado;
        }

        private void SetPedidoComToSession(PedidoComunDto pedidoComunDto)
        {
            HttpContext.Session.SetString("SessionCompraDto", JsonSerializer.Serialize(pedidoComunDto));
        }

        private void SetViewBagCom(PedidoComunDto pedidoComunDto)
        {
            ViewBag.cantidad = pedidoComunDto.Cantidad;
            ViewBag.total = pedidoComunDto.MontoSubtotal;
            ViewBag.catalogo = pedidoComunDto.Lineas;
        }

        public IActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }
        public IActionResult BuscarPorFecha(DateTime fechaEntrega)
        {
            return View("Index", _obtenerPedidos.Ejecutar(fechaEntrega));

        }

        public IActionResult Anular(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró el pedido " + id });
            }
            try
            {
                _anularPedido.Ejecutar(id);
                return RedirectToAction("Index", new { mensaje = "Pedido anulado correctamente."});
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }
        }
    }
}
