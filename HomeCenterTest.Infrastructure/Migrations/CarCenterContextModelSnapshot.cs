﻿// <auto-generated />
using System;
using HomeCenterTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace HomeCenterTest.Infrastructure.Migrations
{
    [DbContext(typeof(CarCenterContext))]
    partial class CarCenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeCenterTest.Core.Entities.Repuesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Marca")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nombre")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("UnidadesInventario")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("ValorActual")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.ToTable("Repuesto");
                });

            modelBuilder.Entity("HomeCenterTest.Core.Entities.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Marca")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nombre")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("ValorMaximo")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("ValorMinimo")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("HomeCenterTest.Core.Entities.Tercero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Direccion")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("IdTipoIdentificacion")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("IdTipoIdentificacionNavigationId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("NumeroIdentificacion")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Telefono")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoIdentificacionNavigationId");

                    b.ToTable("Tercero");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Tercero");
                });

            modelBuilder.Entity("HomeCenterTest.Core.Entities.TipoIdentificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IdTipoIdentificacion")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Descripcion");

                    b.Property<string>("TipoIdenti")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("TipoIdenti");

                    b.HasKey("Id")
                        .HasName("Pk_TipoIdentificacion");

                    b.ToTable("TipoIdentificacion");
                });

            modelBuilder.Entity("HomeCenterTest.Core.Entities.Cliente", b =>
                {
                    b.HasBaseType("HomeCenterTest.Core.Entities.Tercero");

                    b.Property<string>("DireccionFacturacion")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("EmailFacturacion")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("IdTercero")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("IdTerceroNavigationId")
                        .HasColumnType("NUMBER(10)");

                    b.HasIndex("IdTerceroNavigationId");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("HomeCenterTest.Core.Entities.Tercero", b =>
                {
                    b.HasOne("HomeCenterTest.Core.Entities.TipoIdentificacion", "IdTipoIdentificacionNavigation")
                        .WithMany("Terceros")
                        .HasForeignKey("IdTipoIdentificacionNavigationId");

                    b.Navigation("IdTipoIdentificacionNavigation");
                });

            modelBuilder.Entity("HomeCenterTest.Core.Entities.Cliente", b =>
                {
                    b.HasOne("HomeCenterTest.Core.Entities.Tercero", "IdTerceroNavigation")
                        .WithMany("Clientes")
                        .HasForeignKey("IdTerceroNavigationId");

                    b.Navigation("IdTerceroNavigation");
                });

            modelBuilder.Entity("HomeCenterTest.Core.Entities.Tercero", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("HomeCenterTest.Core.Entities.TipoIdentificacion", b =>
                {
                    b.Navigation("Terceros");
                });
#pragma warning restore 612, 618
        }
    }
}
