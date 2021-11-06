using HomeCenterTest.Core.CustomEntities;
using HomeCenterTest.Core.Entities;
using HomeCenterTest.Core.Interfaces;
using HomeCenterTest.Core.Interfaces.IServices;
using HomeCenterTest.Core.QueryFilters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCenterTest.Core.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly string[] _includes;
        //private readonly IProcesosUsuarioService _procesosUsuarioService;

        public PersonaService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions.Value;
            _includes = new string[] { "Cliente" };
        }

        public PagedList<Persona> GetAll(PersonaQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var personas = _unitOfWork.PersonaRepository.GetAll(_includes);


            personas = personas.OrderBy(x => x.Id).ThenBy(x => x.NumeroIdentificacion);

            //Función personalizada que aplica los filtros y la paginación, para devolver los registros que cumplan 
            var pagedPersona = PagedList<Persona>.Create(personas, filters.PageNumber, filters.PageSize);
            return pagedPersona;
        }

        public async Task<Persona> GetById(int id)
        {
            var Persona = await _unitOfWork.PersonaRepository.GetById(id, _includes);
            if (Persona == null)
            {
                throw new Exception("No se encontró la persona que se desea modificar");
            }

            return Persona;
        }

        public async Task<Persona> Add(Persona newPersona)
        {
            await _unitOfWork.PersonaRepository.Add(newPersona);
            await _unitOfWork.SaveChangesAsync();
            return await _unitOfWork.PersonaRepository.GetLastRecord(_includes);
        }

        public async Task<Persona> Update(Persona newPersona)
        {
            var PersonaActual = await GetById(newPersona.Id);
            PersonaActual.IdTipoIdentificacion = newPersona.IdTipoIdentificacion;
            PersonaActual.NumeroIdentificacion = newPersona.NumeroIdentificacion;
            PersonaActual.PrimerNombre = newPersona.PrimerNombre;

            //_unitOfWork.PersonaRepository.Update(PersonaActual);
            await _unitOfWork.SaveChangesAsync();
            return PersonaActual;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {

            await _unitOfWork.PersonaRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        IList<Persona> IPersonaService.GetAll(PersonaQueryFilter filters)
        {
            throw new NotImplementedException();
        }

        Task<Persona> IPersonaService.Add(Persona newEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
