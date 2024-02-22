using Homework3.Applications.IRepositry;
using Homework3.Models;
using Homework3.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace Homework3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChocolateController : Controller
    {
        private IChocolateRepository _chocolateRepository;
        public ChocolateController(IChocolateRepository chocolateRepository)
        {
            _chocolateRepository = chocolateRepository;
        }

        [HttpPost]
        public async Task<string> Create(Chocolate chocolate)
        {
            return await _chocolateRepository.Create(chocolate);
        }

        [HttpPut]
        public async Task<string> Update(int id,ChocolateDTO chocolate)
        {
            return await _chocolateRepository.Update(id,chocolate);
        }

        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            return await _chocolateRepository.Delete(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Chocolate>> Get()
        {
            return await  _chocolateRepository.Get();
        }
    }
}
