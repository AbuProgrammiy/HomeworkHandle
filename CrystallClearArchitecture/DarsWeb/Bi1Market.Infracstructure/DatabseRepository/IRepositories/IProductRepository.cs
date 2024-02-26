using Bi1Market.Domen.Models;
using Bi1Market.DTOs;

namespace Bi1Market.Infrastructure.DatabseRepository.IRepositories
{
    public interface IProductRepository
    {
        public Task<string> Create(ProductDTO productDTO);
        public Task<IEnumerable<Product>> GetAll();
        public Task<string> Update(int id, ProductDTO productDTO);
        public Task<string> Delete(int id);
    }
}
