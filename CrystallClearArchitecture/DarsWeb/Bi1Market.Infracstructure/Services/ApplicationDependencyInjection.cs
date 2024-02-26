using Bi1Market.Infrastructure.DatabseRepository.IRepositories;
using BiOneMarket.Infrastructure.DatabseRepository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiOneMarket.Infrastructure.Services
{
    public static class ApplicationDependencyInjection
        {
            public static IServiceCollection AddAplication(this IServiceCollection services)
            {
                services.AddScoped<IProductRepository, ProductRepository>();
                return services;
            }
        }
    
}
