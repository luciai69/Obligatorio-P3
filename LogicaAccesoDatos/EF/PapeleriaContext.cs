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
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoComun> PedidosComunes { get; set; }
        public DbSet<PedidoExpress> PedidosExpress { get; set; }
        public DbSet<Linea> Lineas { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = papeleria; Integrated Security = True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().OwnsOne(u => u.NombreCompleto, nom =>
            {
                nom.Property(n => n.Nombre).HasColumnName("NombreCompleto_nombre");
                nom.Property(n => n.Apellido).HasColumnName("NombreCompleto_apellido");
            }
          );

            modelBuilder.Entity<Cliente>().OwnsOne(c => c.Direccion, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("Direccion_calle");
                dir.Property(d => d.Num).HasColumnName("Direccion_num");
                dir.Property(d => d.Ciudad).HasColumnName("Direccion_ciudad");
                dir.Property(d => d.DistanciaPapeleria).HasColumnName("Direccion_distPapeleria");
            }
          );
        }
    }
}
