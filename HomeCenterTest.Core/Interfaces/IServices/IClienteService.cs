using HomeCenterTest.Core.Entities;
using HomeCenterTest.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCenterTest.Core.Interfaces.IServices
{
    public interface IClienteService
    {
        IList<Cliente> GetAll(ClienteQueryFilter filters);
        Task<Cliente> GetById(int id);
        Task<Cliente> Add(Cliente newCliente);
        Task<Cliente> Update(Cliente newCliente);
        Task<bool> Delete(int id);
    }
}
