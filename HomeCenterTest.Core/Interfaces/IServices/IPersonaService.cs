using HomeCenterTest.Core.Entities;
using HomeCenterTest.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCenterTest.Core.Interfaces.IServices
{
    public interface IPersonaService
    {
        IList<Persona> GetAll(PersonaQueryFilter filters);
        Task<Persona> GetById(int id);
        Task<Persona> Add(Persona newPersona);
        Task<Persona> Update(Persona newPersona);
        Task<bool> Delete(int id);
    }
}
