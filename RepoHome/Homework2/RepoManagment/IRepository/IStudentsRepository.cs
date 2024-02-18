using Homework2.Entities.DTOs;
using Homework2.Models;

namespace Homework2.RepoManagment.IRepository
{
    public interface IStudentsRepository
    {
        public string CreateStudent(StudentDTO studentDto);
        public IEnumerable<Student> GetAllStudents();
        public string UpdateStudent(int id,StudentDTO studentDto);
        public string DeleteStudent(int id);
    }
}
