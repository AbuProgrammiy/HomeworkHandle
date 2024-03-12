using Microsoft.EntityFrameworkCore;                        // DbContext |ishlashi uchun
using TelegramProject.Application.Abstractions;             // IApplicationDbContext |ishlashi uchun
using TelegramProject.Domain.Entities.Models;               // User |ishlashi uchun

namespace TelegramProject.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        async Task<int> IApplicationDbContext.SaveChanges(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
