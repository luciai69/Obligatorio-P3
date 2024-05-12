using LogicaAccesoDatos.EF;
using LogicaAplicacion.Articulos;
using LogicaAplicacion.Pedidos;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repositorios
builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
builder.Services.AddScoped<IRepositorioPedido, RepositorioPedido>();

//casos de uso articulos
builder.Services.AddScoped<IObtenerTodos<ArticuloDto>, ObtenerArticulos>();

//casos de uso pedidos
builder.Services.AddScoped<IObtenerPorBool<PedidoDto>, ObtenerPedidosPorAnulado>();

// inyecta el contexto 
builder.Services.AddDbContext<PapeleriaContext>(
               options => options.UseSqlServer
               (builder.Configuration.GetConnectionString("papeleria")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
