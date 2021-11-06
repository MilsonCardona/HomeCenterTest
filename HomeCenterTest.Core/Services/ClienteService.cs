using HomeCenterTest.Core.CustomEntities;
using HomeCenterTest.Core.Entities;
using HomeCenterTest.Core.Interfaces;
using HomeCenterTest.Core.Interfaces.IServices;
using HomeCenterTest.Core.QueryFilters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCenterTest.Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly string[] _includes;
        //private readonly IProcesosUsuarioService _procesosUsuarioService;

        public ClienteService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions.Value;
            _includes = new string[] { "IdEmpresaNavigation", "IdProcesoNavigation", "IdSistemaGestionNavigation", "IdTipoDocumentoNavigation", "Versiones" };
        }

        IList<Cliente> IClienteService.GetAll(ClienteQueryFilter filters)
        {
            throw new NotImplementedException();
        }

        public PagedList<Cliente> GetAll(ClienteQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var clientes = _unitOfWork.ClienteRepository.GetAll(_includes);
            clientes = clientes.OrderBy(x => x.Id).ThenBy(x => x.NumeroIdentificacion);

            //Función personalizada que aplica los filtros y la paginación, para devolver los registros que cumplan 
            var pagedCliente = PagedList<Cliente>.Create(clientes, filters.PageNumber, filters.PageSize);
            return pagedCliente;
        }

        public async Task<Cliente> GetById(int id)
        {
            var cliente = await _unitOfWork.ClienteRepository.GetById(id, _includes);
            if (cliente == null)
            {
                throw new Exception("No se encontró la empresa que se desea modificar");
            }

            return cliente;
        }

        public async Task<Cliente> Add(Cliente newCliente)
        {
            await _unitOfWork.ClienteRepository.Add(newCliente);
            await _unitOfWork.SaveChangesAsync();
            return await _unitOfWork.ClienteRepository.GetLastRecord(_includes);
        }

        public async Task<Cliente> Update(Cliente newCliente)
        {
            var clienteActual = await GetById(newCliente.Id);
            clienteActual.IdTercero = newCliente.IdTercero;
            clienteActual.DireccionFacturacion = newCliente.DireccionFacturacion;
            clienteActual.EmailFacturacion = newCliente.EmailFacturacion;

            _unitOfWork.ClienteRepository.Update(clienteActual);
            await _unitOfWork.SaveChangesAsync();
            return clienteActual;
        }

        
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ClienteRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

       
    }
}

