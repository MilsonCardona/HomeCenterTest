using System.Collections.Generic;

namespace HomeCenterTest.Core.Entities
{
    public class Persona : BaseEntity
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public virtual TipoIdentificacion IdTipoIdentificacionNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
