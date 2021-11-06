using HomeCenterTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HomeCenterTest.Infrastructure.Data
{
    public partial class CarCenterContext : DbContext
    {
        public CarCenterContext(DbContextOptions<CarCenterContext> options)
              : base(options)
        {
        }

        public virtual DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Repuesto> Repuesto { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseOracle("TNS_ADMIN = C:\\Users\\milso\\Oracle\\network\\admin; USER ID = CARCENTER_USER; Password=HomeCenter123*; DATA SOURCE = localhost:1521 / XEPDB1; PERSIST SECURITY INFO = True");
                //optionsBuilder.UseOracle("DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\\Users\\milso\\Oracle\\network\\admin;USER ID=SYS; Password=Maricelly2934*;DATA SOURCE=localhost:1521/XEPDB1;PERSIST SECURITY INFO=True");
                //optionsBuilder.UseOracle("DBA PRIVILEGE=SYSDBA; User Id=SYSTEM;Password=mw;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)))");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Register in the context all configuration clases of the entities created into this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
