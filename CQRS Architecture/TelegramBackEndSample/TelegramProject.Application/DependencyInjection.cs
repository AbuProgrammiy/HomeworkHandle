using MediatR;                                          // AddMediatR |ishlashi uchun
using Microsoft.Extensions.DependencyInjection;         // IServiceCollection |ishlashi uchun
using System.Reflection;                                // Assembly |ishlashi uchun

namespace TelegramProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
