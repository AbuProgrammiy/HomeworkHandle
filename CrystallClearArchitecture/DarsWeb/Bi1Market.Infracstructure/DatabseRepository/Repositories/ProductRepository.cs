using Bi1Market.Domen.Models;
using Bi1Market.DTOs;
using Bi1Market.Infrastructure.DatabseRepository.IRepositories;
using Bi1Market.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BiOneMarket.Infrastructure.DatabseRepository.Repositories
{
    //private  ApplicationDbContext _context;

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Create(ProductDTO productDTO)
        {
            await _context.AddAsync(productDTO);
            await _context.SaveChangesAsync();
            return "Malumot qoshildi";
        }

        public async Task<string> Delete(int id)
        {
            var model = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            _context.products.Remove(model);
            await _context.SaveChangesAsync();
            return "Ochirildi";
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<string> Update(int id, ProductDTO productDTO)
        {
            var model = await _context.products.FirstOrDefaultAsync(x => x.Id == id);

            model.Name = productDTO.Name;
            _context.SaveChanges();
            return "Update qilindi";
        }
    }
}
