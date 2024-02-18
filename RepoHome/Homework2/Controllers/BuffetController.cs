using Homework2.Entities.DTOs;
using Homework2.Models;
using Homework2.RepoManagment.IRepository;
using Homework2.RepoManagment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuffetController : Controller
    {
        public readonly IBuffetRepository _buffetRepository;
        public BuffetController(IBuffetRepository repos)
        {
            _buffetRepository = repos;
        }

        [HttpPost]
        public string Create(BuffetDTO buffet)
        {
            return _buffetRepository.CreateBuffet(buffet);
        }

        [HttpGet]
        public IEnumerable<Buffet> GetAll()
        {
            return _buffetRepository.GetAllBuffet();
        }

        [HttpPut]
        public string Update(int id,BuffetDTO buffet)
        {
            return _buffetRepository.UpdateBuffet(id,buffet);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return _buffetRepository.DeleteBuffet(id);
        }
    }
}
