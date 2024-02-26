using Bi1Market.Domen.Models;
using Bi1Market.DTOs;

namespace Bi1Market.Infrastructure.DatabseRepository.IRepositories
{
    public interface IProductRepository
    {
        //public string Create(ProductDTO productDTO);
        //public IEnumerable<Product> GetAll();
        //public string Update(int id, ProductDTO productDTO);
        public string Delete(int id);
    }
}
