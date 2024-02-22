using Homework3.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework3.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Chocolate> chocolates { get; set; }
    }
}
