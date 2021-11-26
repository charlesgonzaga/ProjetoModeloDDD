using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoModeloDDD.Infra.CrossCutting
{
    public static class ConfigureContext
    {
        public static IServiceCollection ResolveContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClientesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ClientesDBConnection")));

            return services;
        }
    }
}
