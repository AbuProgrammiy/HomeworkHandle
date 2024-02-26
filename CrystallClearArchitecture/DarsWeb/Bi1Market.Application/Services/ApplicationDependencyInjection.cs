using BiOneMarket.Infrastructure.DatabseRepository.IRepositories;
using BiOneMarket.Infrastructure.DatabseRepository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BiOneMarket.Infrastructure.Services
{
    public class ApplicationDependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
