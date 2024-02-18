using Homework2.Models;

namespace Homework2.Services.ShowStudentsDish
{
    public interface IShowAllStudentsDishService
    {
        public IEnumerable<StudentsWithDishes> ShowAllStudentsWithDishes();
    }
}
