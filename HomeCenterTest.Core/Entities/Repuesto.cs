using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCenterTest.Core.Entities
{
    public class Repuesto : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorActual { get; set; }
        public int UnidadesInventario { get; set; }
    }
}
