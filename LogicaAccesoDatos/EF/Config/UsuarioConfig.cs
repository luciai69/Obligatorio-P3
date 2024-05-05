using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.EF.Config
{
    internal class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.OwnsOne(u => u.NombreCompleto, nom =>
            {
                nom.Property(n => n.Nombre).HasColumnName("NombreCompleto_nombre");
                nom.Property(n => n.Apellido).HasColumnName("NombreCompleto_apellido");
            }
            );

            builder.HasIndex(u => u.Mail).IsUnique();

        }
    }
}
