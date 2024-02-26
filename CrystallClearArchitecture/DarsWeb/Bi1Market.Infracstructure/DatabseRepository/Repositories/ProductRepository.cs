using Bi1Market.Domen.Models;
using Bi1Market.DTOs;
using Bi1Market.Infrastructure.DatabseRepository.IRepositories;

namespace BiOneMarket.Infrastructure.DatabseRepository.Repositories
{
    //private  ApplicationDbContext _context;

    public class ProductRepository : IProductRepository
    {
        public string Delete(int id)
        {
            return "salom";
        }
    }
}
