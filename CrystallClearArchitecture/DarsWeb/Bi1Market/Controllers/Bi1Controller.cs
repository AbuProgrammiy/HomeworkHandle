using Bi1Market.Domen.Models;
using Bi1Market.DTOs;
//using Bi1Market.Infrastructure.DatabseRepository.Repositories;
using Bi1Market.Infrastructure.DatabseRepository.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Bi1Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bi1Controller : Controller
    {
        private IProductRepository _context;
        public Bi1Controller(IProductRepository context)
        {
            _context = context;
        }

        [HttpPost]
        public string Create(ProductDTO productDTO)
        {
            return  _context.Create(productDTO).GetAwaiter().GetResult();
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _context.GetAll().GetAwaiter().GetResult();
        }

        [HttpPut]
        public string Update(int id, ProductDTO productDTO)
        {
            return _context.Update(id, productDTO).GetAwaiter().GetResult();
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return  _context.Delete(id).GetAwaiter().GetResult();
        }
    }
}
