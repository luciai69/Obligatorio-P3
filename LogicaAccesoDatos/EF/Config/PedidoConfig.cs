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
    internal class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasOne(ped => ped.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(c => c.ClienteId);

            builder.HasMany(ped => ped.Lineas);

        }
    }
}
