using HomeCenterTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeCenterTest.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(e => e.Id).HasName("Pk_Cliente");

            builder.HasIndex(e => e.IdTerceroNavigation, "fk_Cliente_Tercero_idx");

            builder.Property(e => e.IdTercero)
                .IsRequired()
                .HasColumnName("IdTercero");

            builder.Property(e => e.DireccionFacturacion)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnName("Direccion");

            builder.Property(e => e.EmailFacturacion)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .HasColumnName("Email");

            builder.HasOne(d => d.IdTerceroNavigation)
               .WithMany(p => p.Clientes)
               .HasForeignKey(d => d.IdTercero)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("fk_cliente_tercero");

        }
    }
}
