using HomeCenterTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeCenterTest.Infrastructure.Data.Configurations
{
    public class TipoIdentificacionConfiguration : IEntityTypeConfiguration<TipoIdentificacion>
    {
        public void Configure(EntityTypeBuilder<TipoIdentificacion> builder)
        {
            builder.ToTable("TipoIdentificacion");
            builder.HasKey(e => e.Id).HasName("Pk_TipoIdentificacion");

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("IdTipoIdentificacion")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.TipoIdenti)
               .HasColumnType("varchar(2)")
               .HasColumnName("TipoIdenti")
               .IsRequired(true);

            builder.Property(e => e.Descripcion)
               .HasColumnType("varchar(50)")
               .HasColumnName("Descripcion")
               .IsRequired(true);
        }
    }
}
