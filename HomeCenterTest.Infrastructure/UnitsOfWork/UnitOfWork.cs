using HomeCenterTest.Core.Entities;
using HomeCenterTest.Core.Interfaces;
using HomeCenterTest.Infrastructure.Data;
using HomeCenterTest.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace HomeCenterTest.Infrastructure.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarCenterContext _context;
        private readonly IGenericRepository<Cliente> _clienteRepository;
        private readonly IGenericRepository<Persona> _personaRepository;

        public UnitOfWork(CarCenterContext context)
        {
            _context = context;
        }

        public IGenericRepository<Cliente> DocumentoRepository => _clienteRepository ?? new GenericRepository<Cliente>(_context);

        public IGenericRepository<Cliente> ClienteRepository => _clienteRepository ?? new GenericRepository<Cliente>(_context);
        public IGenericRepository<Persona> PersonaRepository => _personaRepository ?? new GenericRepository<Persona>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
