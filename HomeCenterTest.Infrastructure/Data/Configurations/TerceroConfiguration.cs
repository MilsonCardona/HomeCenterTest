using HomeCenterTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeCenterTest.Infrastructure.Data.Configurations
{
    public class TerceroConfiguration
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Tercero");
            builder.HasKey(e => e.Id).HasName("Pk_Tercero");
            builder.HasIndex(e => e.NumeroIdentificacion, "Uk_NumeroIdentificacion")
               .IsUnique();

            builder.HasIndex(e => e.IdTipoIdentificacion, "fk_TipoIdentificacion_idx");

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("IdTercero")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.IdTipoIdentificacion)
               .IsRequired()
                .HasColumnName("IdTipoIdentificacion");

            builder.Property(e => e.NumeroIdentificacion)
               .HasColumnType("numeric(12)")
               .HasColumnName("NumeroIdentificacion")
               .IsRequired(true);

            builder.Property(e => e.PrimerNombre)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnName("PrimerNombre");

            builder.Property(e => e.SegundoNombre)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnName("SegundoNombre");

            builder.Property(e => e.PrimerApellido)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnName("PrimerApellido");

            builder.Property(e => e.SegundoApellido)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnName("SegundoApellido");

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .HasColumnName("Direccion");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .HasColumnName("Email");

            builder.Property(e => e.Celular)
                .IsRequired()
                .HasColumnType("numeric(10)")
                .HasColumnName("Celular");

            builder.Property(e => e.Telefono)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .HasColumnName("Telefono");

            builder.HasOne(d => d.IdTipoIdentificacionNavigation)
               .WithMany(p => p.Terceros)
               .HasForeignKey(d => d.IdTipoIdentificacion)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("fk_tercero_tipoidentificacion");
        }
    }
}
