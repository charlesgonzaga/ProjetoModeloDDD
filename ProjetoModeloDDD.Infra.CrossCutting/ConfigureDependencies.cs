using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using ProjetoModeloDDD.Domain.DTOs.Configurations;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Infra.Repositories;
using ProjetoModeloDDD.Service;
using System;
using System.Net.Http;

namespace ProjetoModeloDDD.Infra.CrossCutting
{
    public static class ConfigureDependencies
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ClientesDbContext>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.Configure<StarWarsOptions>(configuration.GetSection("StarWarsService"));

            services.InjectingServices(configuration);
            services.InjectingRepositories();

            return services;
        }

        public static IServiceCollection InjectingServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPessoaService, PessoaService>();

            var secao = configuration.GetSection("StarWarsService");
            services.AddHttpClient<IStarWarsService, StarWarsService>(
                        client => client.BaseAddress = new Uri(secao["UrlBase"])
                    )
                    .AddPolicyHandler(GetRetryPolicy())
                    .AddPolicyHandler(GetCircuitBreakerPolicy());

            return services;
        }

        public static IServiceCollection InjectingRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
            => HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
            => HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
    }
}
