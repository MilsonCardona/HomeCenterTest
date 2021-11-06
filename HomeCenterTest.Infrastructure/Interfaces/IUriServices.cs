using HomeCenterTest.Core.QueryFilters;
using System;

namespace HomeCenterTest.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetClientePaginationUri(ClienteQueryFilter filter, string actionUrl);
        Uri GetPersonaPaginationUri(PersonaQueryFilter filter, string actionUrl);
    }
}
