using System.Collections.Generic;

namespace HomeCenterTest.Core.Entities
{
    public class TipoIdentificacion : BaseEntity
    {
        public TipoIdentificacion()
        {
            Terceros = new HashSet<Persona>();
        }
        public string TipoIdenti { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Terceros { get; set; }
    }
}
