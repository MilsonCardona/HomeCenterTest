using HomeCenterTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeCenterTest.Infrastructure.Data.Configurations
{
    public class RepuestoConfiguration
    {
        public void Configure(EntityTypeBuilder<Repuesto> builder)
        {
            builder.ToTable("Repuesto");

            builder.HasKey(e => e.Id)
                .HasName("Pk_Repuesto");

            builder.Property(e => e.Id)
               .IsRequired()
               .HasColumnName("IdRepuesto")
               .ValueGeneratedOnAdd();

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200)
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

            builder.Property(e => e.ValorActual)
               .HasColumnType("decimal(12,2)")
               .HasColumnName("ValorActual")
               .IsRequired(true);

            builder.Property(e => e.UnidadesInventario)
               .HasColumnType("Numeric(5)")
               .HasPrecision(0)
               .HasColumnName("UnidadesInventario")
               .IsRequired(true);
        }
    }
}
