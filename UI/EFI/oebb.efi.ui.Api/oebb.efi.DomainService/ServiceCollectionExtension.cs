using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace oebb.efi.Domain.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());            

            return services;
        }
    }
}
