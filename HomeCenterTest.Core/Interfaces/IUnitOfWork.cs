using HomeCenterTest.Core.Entities;
using System;
using System.Threading.Tasks;

namespace HomeCenterTest.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Cliente> ClienteRepository { get; }
        IGenericRepository<Persona> PersonaRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
