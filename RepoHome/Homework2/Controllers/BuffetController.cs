using Homework2.Entities.DTOs;
using Homework2.RepoManagment.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuffetController : Controller
    {
        public readonly IBuffetRepository _buffetRepository;
        [HttpPost]
        public string Create(BuffetDTO buffet)
        {
            return _buffetRepository.CreateBuffet(buffet);
        }
    }
}
