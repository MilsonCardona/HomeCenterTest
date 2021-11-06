namespace HomeCenterTest.Core.Entities
{
    public class Servicio : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public decimal ValorMinimo { get; set; }
        public decimal ValorMaximo { get; set; }
    }
}
