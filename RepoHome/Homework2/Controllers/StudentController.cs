using Homework2.Entities.DTOs;
using Homework2.Models;
using Homework2.RepoManagment.IRepository;
using Homework2.RepoManagment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : Controller
    {
        public readonly IStudentsRepository _studentsRepositories;
        public StudentController(IStudentsRepository repos)
        {
            _studentsRepositories = repos;
        }

        [HttpPost]
        public string Create(StudentDTO student)
        {
            return _studentsRepositories.CreateStudent(student);
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _studentsRepositories.GetAllStudents();
        }

        [HttpPut]
        public string Update(int id, StudentDTO student)
        {
            return _studentsRepositories.UpdateStudent(id, student);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return _studentsRepositories.DeleteStudent(id);
        }
    }
}
