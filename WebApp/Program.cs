using LogicaAccesoDatos.EF;
using LogicaAplicacion.Articulos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfacesRepositorio;

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

            // CASOS DE USO
            builder.Services.AddScoped<IAlta<Articulo>, AltaArticulo>();
            builder.Services.AddScoped<IObtenerTodos<Articulo>, ObtenerArticulos>();

            // estos no van creo, no son necesarios estos casos de uso segun la letra. preguntar al profe.
            builder.Services.AddScoped<IEditar<Articulo>,  EditarArticulo>();
            builder.Services.AddScoped<IEliminar<Articulo>, EliminarArticulo>();
            builder.Services.AddScoped<IObtener<Articulo>, ObtenerArticulo>();

            // inyecta el contexto 
            builder.Services.AddDbContext<PapeleriaContext>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
