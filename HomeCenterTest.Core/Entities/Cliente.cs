namespace HomeCenterTest.Core.Entities
{
    public class Cliente : Persona
    {
        public int IdTercero { get; set; }
        public string EmailFacturacion { get; set; }
        public string DireccionFacturacion { get; set; }

        public virtual Persona IdTerceroNavigation { get; set; }
    }
}
