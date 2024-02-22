using Homework3.Applications.IRepositry;
using Homework3.Infrastructure;
using Homework3.Models;
using Homework3.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace Homework3.Applications.Repository
{
    public class ChocolateRepository : IChocolateRepository
    {
        public ApplicationDbContext _context { get; set; }
        public ChocolateRepository(ApplicationDbContext contex)
        {
            _context = contex;
        }
        public async Task<string> Create(Chocolate chocolate)
        {
            await _context.AddAsync(chocolate);
            await _context.SaveChangesAsync();
            return "Malumot qoshildi";
        }

        public async Task<string> Update(int id,ChocolateDTO chocolate)
        {
            var model = await _context.chocolates.FirstOrDefaultAsync(x=>x.Id == id);
           
            model.Name = chocolate.Name;
            model.price = chocolate.price;
            _context.SaveChanges();
            return "Update qilindi";
        }

        public async Task<string> Delete(int id)
        {
            var model = await _context.chocolates.FirstOrDefaultAsync(x => x.Id == id);
            _context.chocolates.Remove(model);
            await _context.SaveChangesAsync();
            return "Ochirildi";
        }

        public async Task<IEnumerable<Chocolate>> Get()
        {
            return await _context.chocolates.ToListAsync();
        }
    }
}