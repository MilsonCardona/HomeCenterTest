using HomeCenterTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeCenterTest.Infrastructure.Data.Configurations
{
    public class ServicioConfiguration
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.ToTable("Servicio");

            builder.HasKey(e => e.Id)
                .HasName("Pk_servicio");

            builder.Property(e => e.Id)
               .IsRequired()
               .HasColumnName("IdServicio")
               .ValueGeneratedOnAdd();

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnType("varchar")
                .HasPrecision(200, 0)
                .HasColumnName("Nombre");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .HasColumnName("Descripcion");

            builder.Property(e => e.Marca)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnName("Marca");

            builder.Property(e => e.ValorMinimo)
               .HasColumnType("decimal(12,2)")
               .HasColumnName("ValorMinimo")
               .IsRequired(true);

            builder.Property(e => e.ValorMaximo)
               .HasColumnType("decimal(12,2)")
               .HasColumnName("ValorMaximo")
               .IsRequired(true);
        }
    }
}
