using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Repositories;
using Project.Domen.Entities.Models;

namespace Project.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenCRUDController : ControllerBase
    {
        private readonly IRepository repository;

        public TokenCRUDController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public string Create(User user)
        {
            return repository.Create(user);
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return repository.Read();
        }

        [HttpPatch]
        public string Patch(int id,User user)
        {
            return repository.Update(id, user);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
