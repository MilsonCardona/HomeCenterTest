using HomeCenterTest.Core.CustomEntities;
using HomeCenterTest.Core.Interfaces;
using HomeCenterTest.Core.Interfaces.IServices;
using HomeCenterTest.Core.Services;
using HomeCenterTest.Infrastructure.Data;
using HomeCenterTest.Infrastructure.Interfaces;
using HomeCenterTest.Infrastructure.Repositories;
using HomeCenterTest.Infrastructure.Services;
using HomeCenterTest.Infrastructure.UnitsOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeCenterTest.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<CarCenterContext>(dbContextOptions =>
                    dbContextOptions.UseOracle("TNS_ADMIN = C:\\Users\\milso\\Oracle\\network\\admin; USER ID = CARCENTER_USER; Password=HomeCenter123*; DATA SOURCE = localhost:1521 / XEPDB1; PERSIST SECURITY INFO = True")
                   .EnableSensitiveDataLogging()
                   .EnableDetailedErrors());
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IPersonaService, PersonaService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //this register have two feature, in first place with "AddSingleton" so that create one and only one instance of "UriService" for all application, 
            //and in second place to buildind dinamically the "NextPage" and "PreviosPage" Uri of the pagination to pass to the client.
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }
    }

}
