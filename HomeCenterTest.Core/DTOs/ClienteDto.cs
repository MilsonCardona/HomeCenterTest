using HomeCenterTest.Core.Entities;

namespace HomeCenterTest.Core.DTOs
{
    public class ClienteDto
    {
        public int IdTercero { get; set; }
        public string EmailFacturacion { get; set; }
        public string DireccionFacturacion { get; set; }

        public virtual Persona IdTerceroNavigation { get; set; }
    }
}
