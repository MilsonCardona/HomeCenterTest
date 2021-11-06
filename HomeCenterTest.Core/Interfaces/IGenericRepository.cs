using HomeCenterTest.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCenterTest.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(string[] includes);
        Task<T> GetById(int id);
        Task<T> GetById(int id, string[] includes);
        Task<T> GetLastRecord();
        Task<T> GetLastRecord(string[] includes);
        Task Add(T newEntity);
        void Update(T newEntity);
        Task Delete(int id);
    }
}
