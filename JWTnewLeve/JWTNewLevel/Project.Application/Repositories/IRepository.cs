using Project.Domen.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories
{
    public interface IRepository
    {
        public string Create(User user);
        public IEnumerable<User> Read();
        public string Update(int id,User user);
        public string Delete(int id);
    }
}
