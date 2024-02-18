using Homework2.Entities.DTOs;
using Homework2.Models;

namespace Homework2.RepoManagment.IRepository
{
    public interface IBuffetRepository
    {
        public string CreateBuffet(BuffetDTO buffetDto);
        public IEnumerable<Buffet> GetAllBuffet();
        public string UpdateBuffet(int id,BuffetDTO buffetDto);
        public string DeleteBuffet(int id);
    }
}
