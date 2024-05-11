using LogicaAccesoDatos.EF;
using LogicaAplicacion.Articulos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.CarpetaDtos;
using LogicaAplicacion.Usuarios;
using LogicaAplicacion.Clientes;
using Microsoft.EntityFrameworkCore;
using LogicaAplicacion.Pedidos;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // REPOSITORIOS
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedido>();


            // CASOS DE USO
            //Usuarios
            builder.Services.AddScoped<IAlta<AdminDto>, AltaUsuario>();
            builder.Services.AddScoped<IEditar<UsuarioDto>, EditarUsuario>();
            builder.Services.AddScoped<IEliminar<Usuario>, EliminarUsuario>();
            builder.Services.AddScoped<IObtener<UsuarioDto>, ObtenerUsuario>();
            builder.Services.AddScoped<IObtenerTodos<UsuarioDto>, ObtenerUsuarios>();
            builder.Services.AddScoped<IObtenerPorDosString<Usuario>, ObtenerPorDosString>();


            //Clientes
            builder.Services.AddScoped<IObtenerTodos<ClienteDto>, ObtenerClientes>();
            builder.Services.AddScoped<IObtenerPorString<ClienteDto>, ObtenerPorString>();
            builder.Services.AddScoped<IObtenerPorInt<ClienteDto>, ObtenerPorInt>();

            //Articulos
            builder.Services.AddScoped<IAlta<ArticuloDto>, AltaArticulo>();
            builder.Services.AddScoped<IObtenerTodos<ArticuloDto>, ObtenerArticulos>();

            // estos no van creo, no son necesarios estos casos de uso segun la letra. preguntar al profe.
            builder.Services.AddScoped<IEditar<Articulo>,  EditarArticulo>();
            builder.Services.AddScoped<IEliminar<Articulo>, EliminarArticulo>();

            //Pedido
            builder.Services.AddScoped<IObtener<Articulo>, ObtenerArticulo>();
            builder.Services.AddScoped<IObtener<Cliente>, ObtenerCliente>();
            builder.Services.AddScoped<IAlta<PedidoExpressDto>, AltaPedidoExpress>();
            builder.Services.AddScoped<IAlta<PedidoComunDto>, AltaPedidoComun>();
            builder.Services.AddScoped<IObtenerPorFecha<PedidoDto>, ObtenerPedidosPorFecha>();
            builder.Services.AddScoped<IAnular<Pedido>, AnularPedido>();


            // inyecta el contexto 
            builder.Services.AddDbContext<PapeleriaContext>(
                options => options.UseSqlServer
                (builder.Configuration.GetConnectionString("papeleria")));

            builder.Services.AddSession();

            //Lee json con parametros generales
            var config = new ConfigurationBuilder()
                .AddJsonFile("parametrosgenerales.json", optional: true, reloadOnChange: true)
                .Build();
            ParametrosGenerales.Iva = config.GetValue<int>("Iva");
            ParametrosGenerales.MaxLargoArticulo = config.GetValue<int>("MaxLargoArticulo");
            ParametrosGenerales.MinLargoArticulo = config.GetValue<int>("MinLargoArticulo");
            ParametrosGenerales.Plazo = config.GetValue<int>("Plazo");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
