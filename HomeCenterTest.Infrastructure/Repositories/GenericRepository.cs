using HomeCenterTest.Core.Entities;
using HomeCenterTest.Core.Interfaces;
using HomeCenterTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCenterTest.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        //this property is protected to that be visible in other inherited classes of this
        private readonly CarCenterContext _context;
        protected readonly DbSet<T> _entities;

        public GenericRepository(CarCenterContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }


        /// <summary>
        /// consulta todos los registros de T y les adiciona todas las tablas relacionadas que se incluyan en el array de includes 
        /// </summary>
        /// <param name="includes">Array con las tablas relacionadas que se desean incluir en la consulta</param>
        /// <returns>Devuelve una lista de todos los registro</returns>
        public IQueryable<T> GetAll(string[] includes = null)
        {
            var query = _entities.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        /// <summary>
        /// Consulta todos los registros de T
        /// </summary>
        /// <returns>Devuelve todos los registros de T</returns>
        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }


        /// <summary>
        /// Consulta los registros por un ID específico 
        /// </summary>
        /// <param name="id">Id, clave primaria</param>
        /// <returns>los registros que cumplan con el ID</returns>
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        /// <summary>
        /// consulta todos los registros que cumplan con el ID
        /// </summary>
        /// <param name="id">Id a buscar</param>
        /// <param name="includes">Array con las tablas relacionadas que se desean incluir en la consulta</param></param>
        /// <returns>devuelve los registros que cumplan con el ID e incluye todas las clases relacionadas que esten en el array de includes</returns>
        public async Task<T> GetById(int id, string[] includes = null)
        {
            var query = _entities.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            //return await _entities.FindAsync(id);
            return await query.FirstOrDefaultAsync(i => i.Id == id); ;
        }

        /// <summary>
        /// consulta el último id almacenado
        /// </summary>
        /// <returns>devuelve el último registro almacenado</returns>
        public async Task<T> GetLastRecord()
        {
            int ultimoId = _entities.Max(x => x.Id);
            return await GetById(ultimoId);
            //return await _entities.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// consulta el último id almacenado
        /// </summary>
        /// <param name="includes">lista de navigators</param>
        /// <returns>devuelve el último registro almacenado</returns>
        public async Task<T> GetLastRecord(string[] includes = null)
        {
            //string[] _includes = new string[] { "IdEmpresaNavigation", "IdProcesoNavigation", "IdSistemaGestionNavigation", "IdTipoDocumentoNavigation" };
            int ultimoId = _entities.Max(x => x.Id);
            return await GetById(ultimoId, includes);
        }

        /// <summary>
        /// Adiciona una nueva entidad
        /// </summary>
        /// <param name="entity">la entidad</param>
        /// <returns></returns>
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        /// <summary>
        /// Modifica una entidad
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        /// <summary>
        /// elimina la entidad que cumpla con el ID
        /// </summary>
        /// <param name="id">id de la entidad que se desea eliminar</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}
