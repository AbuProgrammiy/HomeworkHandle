using Homework2.Models;
using Npgsql;
using Dapper;

namespace Homework2.Services.ShowStudentsDish
{
    public class ShowAllStudentsDishService : IShowAllStudentsDishService
    {
        public NpgsqlConnection Conncetion=new NpgsqlConnection(connectionString);
        public static string connectionString = "Server=localhost;Port=5432;Database=Homework;User Id=postgres;Password=root;";


        public IEnumerable<StudentsWithDishes> ShowAllStudentsWithDishes()
        {
            return Conncetion.Query<StudentsWithDishes>("select s.id, s.name, l.dishname as launchDish, d.dishname as dinnerDish from students as s " +
                "inner join buffet as l on l.id=s.launchId " +
                "inner join buffet as d on d.id=s.dinnerId;");
        }
    }
}
