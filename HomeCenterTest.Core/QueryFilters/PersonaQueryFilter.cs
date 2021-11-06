using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCenterTest.Core.QueryFilters
{
    public class PersonaQueryFilter
    {
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
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
