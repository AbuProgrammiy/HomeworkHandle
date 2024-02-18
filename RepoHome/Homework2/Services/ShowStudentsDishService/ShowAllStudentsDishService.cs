using Homework2.Models;
using Npgsql;
using Dapper;

namespace Homework2.Services.ShowStudentsDish
{
    public class ShowAllStudentsDishService : IShowAllStudentsDishService
    {
        public NpgsqlConnection Conncetion;
        public string connectionString = "Server=localhost;Port=5432;Database=Homework;User Id=postgres;Password=root;";

        public IEnumerable<StudentsWithDishes> ShowAllStudentsWithDishes()
        {
            return Conncetion.Query<StudentsWithDishes>("select s.id, s.name, l.dishname,d.dishname from students as s " +
                "inner join buffet as l on l.id=student.launchId " +
                "inner join buffet as d on d.id=student.dinnerId;").ToList();
        }
    }
}
