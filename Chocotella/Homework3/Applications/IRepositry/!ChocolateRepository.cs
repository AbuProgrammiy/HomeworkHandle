using Homework3.Models;
using Homework3.ModelsDTO;

namespace Homework3.Applications.IRepositry
{
    public interface IChocolateRepository
    {
        public Task<string> Create(Chocolate chocolate);
        public Task<string> Update(int id,ChocolateDTO chocolate);
        public Task<string> Delete(int id);
        public Task<IEnumerable<Chocolate>> Get();
    }
}
