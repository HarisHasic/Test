using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace oebb.efi.DataAccess.Extensions
{
    public static class EfiContextService
    {
        public static IServiceCollection AddEfiContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EfiContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
    }
}
