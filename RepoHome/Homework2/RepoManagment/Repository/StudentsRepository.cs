using Homework2.Entities.DTOs;
using Homework2.Models;
using Homework2.RepoManagment.IRepository;
using Npgsql;
using Dapper;

namespace Homework2.RepoManagment.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        public NpgsqlConnection Connection;
        public string connectionString = "Server=localhost;Port=5432;Database=Homework;User Id=postgres;Password=root;";
        public IConfiguration _config;
        public StudentsRepository(IConfiguration config)
        {
            _config = config;
            try
            {
                Connection = new NpgsqlConnection(connectionString);
                Connection.Execute("create table Students(id int, Name varchar(255),LaunchId int,DinnerId int);");
                Connection.Execute("insert into Students values(1,'Abdukholiq',1,2)," +
                                                              "(2,'Abdulloh',2,3)," +
                                                              "(3,'Izzat',1,1);");
            }
            catch { }
        }
        public string CreateStudent(StudentDTO studentDto)
        {
            string query = "insert into students(name,launchId,dinnerId) values(@Name,@LaunchId,@DinnerId);";
            StudentDTO parametrs = new StudentDTO()
            {
                Name = studentDto.Name,
                LaunchId = studentDto.LaunchId,
                DinnerId = studentDto.DinnerId,
            };
            Connection.Execute(query, parametrs);
            return "Ma'lumot qo'shildi\n GetAll orqali ko'rishingiz mumkin!";
        }

        public IEnumerable<Student> GetAllStudents()
        {
            string query = "select * from students;";
            return Connection.Query<Student>(query).ToList();
        }

        public string UpdateStudent(int id,StudentDTO studentDto)
        {
            string query = "update students set name=@Name,launchId=@LaunchId,dinnerId=@DinnerId where id=@id";

            int i = Connection.Execute(query, new { 
                id=id,
                Name=studentDto.Name,
                LaunchId=studentDto.LaunchId,
                DinnerId=studentDto.DinnerId,
            });
            if (i == 0)
                return $"{id} id li Student mavjud emas)";
            else
                return "Student Update qilindi";
        }

        public string DeleteStudent(int id)
        {
            string query = "delete from students where id = @id";
            int i=Connection.Execute(query, new { id=id });
            if (i == 0)
                return $"{id} id li Student mavjud emas)";
            else
                return "Ochib ketti bechora";
        }
    }
}
