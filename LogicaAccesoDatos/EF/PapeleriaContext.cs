using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAccesoDatos.EF
{
    public class PapeleriaContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = papeleria; Integrated Security = True");

        }
    }
}
