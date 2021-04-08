using System;
using Application.Domain;
using Application.Posts;
using Infrastructure.FundaApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<FundaApiClient>("FundaApiClient", config =>
            {
                config.BaseAddress = new Uri("http://partnerapi.funda.nl/");
                config.Timeout = TimeSpan.FromSeconds(30);
            });

            services.AddTransient<IAanbodApi, AanbodApi>();
            services.AddTransient<IMakelaarApi, MakelaarService>();
         

            return services;
        }
    }
}