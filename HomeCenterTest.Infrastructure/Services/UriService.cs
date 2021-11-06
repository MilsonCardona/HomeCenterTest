using HomeCenterTest.Core.QueryFilters;
using HomeCenterTest.Infrastructure.Interfaces;
using System;

namespace HomeCenterTest.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetClientePaginationUri(ClienteQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }


        public Uri GetPersonaPaginationUri(PersonaQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
