using LogicaAplicacion.Articulos;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApp.Controllers
{
    public class PedidoController : Controller
    {
        IObtener<Articulo> _obtenerArticulo;
        IObtenerTodos<ArticuloDto> _obtenerArticulos;
        IObtenerTodos<ClienteDto> _obtenerClientes;
        IAlta<PedidoExpressDto> _altaPedidoExpress;

        public PedidoController(
            IObtener<Articulo> obtenerArticulo,
            IObtenerTodos<ArticuloDto> obtenerArticulos,
            IObtenerTodos<ClienteDto> obtenerClientes,
            IAlta<PedidoExpressDto> altaPedidoExpress)
        {
            _obtenerArticulo = obtenerArticulo;
            _obtenerArticulos = obtenerArticulos;
            _obtenerClientes = obtenerClientes;
            _altaPedidoExpress = altaPedidoExpress;
        }


        public IActionResult Catalogo()
        {
            return View(_obtenerArticulos.Ejecutar());
        }

        [HttpPost]
        public IActionResult AgregarLinea(int idArticulo, int cantidad)
        {
            try
            {
                Articulo articulo = _obtenerArticulo.Ejecutar(idArticulo);

                if (articulo == null)
                {
                    throw new Exception("Debe seleccionar un articulo");//TODO implementar esta exception
                }

                PedidoExpressDto pedidoDto = GetPedidoFromSession();
                if (pedidoDto == null)
                {
                    throw new Exception("No se pudo recuperar el pedido.");//TODO implementar esta exception
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

                SetViewBag(pedidoDto);
                SetPedidoToSession(pedidoDto);
                ViewBag.Error = false;
                ViewBag.Mensaje = "Se dio de alta con exito";
            }
            catch (Exception e)
            {
                ViewBag.Error = true;
                ViewBag.Mensaje = e.Message;
            }
            return View("Catalogo", _obtenerArticulos.Ejecutar());
        }

        public void Checkout(int IdCliente, DateTime fechaEntrega)
        {
            PedidoExpressDto pedidoExpressDto = GetPedidoFromSession();

            if (pedidoExpressDto == null)
            {
                throw new Exception("No se pudo recuperar la compra");
            }
            pedidoExpressDto.ClienteId = IdCliente;
            //DateTime dtFecha = DateTime.Parse(fechaEntrega);
            pedidoExpressDto.FechaEntrega = fechaEntrega;
            _altaPedidoExpress.Ejecutar(pedidoExpressDto);

            //ViewBag.MontoTotal = 
            //return View("Catalogo",)

        }

        private PedidoExpressDto GetPedidoFromSession()
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
        
        private void SetPedidoToSession(PedidoExpressDto pedidoExpressDto)
        {
            HttpContext.Session.SetString("SessionCompraDto", JsonSerializer.Serialize(pedidoExpressDto));
        }

        private void SetViewBag(PedidoExpressDto pedidoExpressDto)
        {
            ViewBag.cantidad = pedidoExpressDto.Cantidad;
            ViewBag.total = pedidoExpressDto.MontoSubtotal;
            ViewBag.catalogo = pedidoExpressDto.Lineas;
        }
    }
}
