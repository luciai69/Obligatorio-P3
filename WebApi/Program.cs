using LogicaAccesoDatos.EF;
using LogicaAplicacion.Articulos;
using LogicaNegocio.CarpetaDtos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repositorios
builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();

//casos de uso articulos
builder.Services.AddScoped<IObtenerTodos<ArticuloDto>, ObtenerArticulos>();

// inyecta el contexto 
builder.Services.AddDbContext<PapeleriaContext>();

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
