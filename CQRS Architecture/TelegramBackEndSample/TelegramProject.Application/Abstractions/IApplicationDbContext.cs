using Microsoft.EntityFrameworkCore;                            // User |ishlashi uchun
using TelegramProject.Domain.Entities.Models;                   // DbSet |ishalshi uchun

namespace TelegramProject.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<User>  Users { get; set; }

        Task<int> SaveChanges(CancellationToken cancellationToken=default); // voris olganda implement qilmaslik uchun default parametr berilmoqda)
    }
}
