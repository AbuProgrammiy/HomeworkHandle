using Microsoft.EntityFrameworkCore;                    // UseNpgsql |ishlasi uchun
using Microsoft.Extensions.Configuration;               // IConfiguration |ishlashi uchun
using Microsoft.Extensions.DependencyInjection;         // IServiceCollection |ishlashi uchun
using TelegramProject.Application.Abstractions;         // IApplicationDbContext|ishlashi uchun
using TelegramProject.Infrastructure.Persistance;       // ApplicationDbContext |ishlashi uchun

namespace TelegramProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(config["ConnectionStrings:DefaultConnection"]);
            });
            return services;
        }
    }
}
