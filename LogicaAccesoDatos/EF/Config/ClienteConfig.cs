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
    internal class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.OwnsOne(c => c.Direccion, dir =>
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
