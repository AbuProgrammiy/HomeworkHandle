using Homework2.Models;
using Homework2.Services;
using Homework2.Services.ShowStudentsDish;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentAndDishController
    {
        public readonly IShowAllStudentsDishService _showAllStudentsAndDish;
        public StudentAndDishController(IShowAllStudentsDishService repos)
        {
            _showAllStudentsAndDish = repos;
        }

        [HttpGet]
        public IEnumerable<StudentsWithDishes> GetStudetsAndTheirDishes()
        {
            return _showAllStudentsAndDish.ShowAllStudentsWithDishes();
        }
    }
}
