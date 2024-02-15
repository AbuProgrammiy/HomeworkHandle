using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SupportDars.Models;

namespace SupportDars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LearningCenterController : ControllerBase
    {
        public LearningCenterController()
        {
            Connection=new NpgsqlConnection(connectionstring);
            Connection.Open();
            StartUp();
        }
        public string connectionstring = "Server=localhost;Port=5432;Database=Homework;User Id=postgres;Password=root;";
        public NpgsqlConnection Connection;

        private void StartUp()
        {
            try
            {
                Connection.Execute("create table students(id serial,name varchar(255));");
                Connection.Execute("create table courses(id serial,name varchar(255));");
                Connection.Execute("create table studentsANDcourses(studentId int,courseId int);");
                Connection.Execute("insert into students(name) values" +
                                   "('Abdukholiq')," +
                                   "('Ozod')," +
                                   "('Ibrohim')," +
                                   "('Nuriddin');");
                Connection.Execute("insert into courses(name) values" +
                                   "('Najot Talim')," +
                                   "('11 - maktab')," +
                                   "('Proweb')," +
                                   "('BePro');");
                Connection.Execute("insert into studentsANDcourses values" +
                                   "(1,1)," +
                                   "(2,2)," +
                                   "(3,3)," +
                                   "(4,4)," +
                                   "(1,3)," +
                                   "(1,2)");
            }
            catch (Exception ex){ Console.WriteLine(ex); }
        }

        [HttpGet("Students")]
        public List<Students> GetStudents()
        {
            List<Students> students;
            string query = "select id, name from students";
            students= Connection.Query<Students>(query).ToList();
            for(int i = 0; i < students.Count; i++)
            {
                students[i].Courses = Connection.Query<string>($"select courses.name from studentsANDcourses Inner join courses on courses.id=studentsANDcourses.courseId  where studentsANDcourses.studentId={students[i].Id} ").ToList();
            }
            return students;
        }

        [HttpGet("Courses")]
        public List<Courses> GetCourses()
        {
            List<Courses> courses;
            string query = "select id, name from courses";
            courses = Connection.Query<Courses>(query).ToList();
            for (int i = 0; i < courses.Count; i++)
            {
                courses[i].Students = Connection.Query<string>($"select students.name from studentsANDcourses Inner join students on students.id=studentsANDcourses.studentId  where studentsANDcourses.courseId={courses[i].Id} ").ToList();
            }
            return courses;
        }

        [HttpGet("studentANDcourse")]
        public List<studentANDcourse> GetstudentAndcourse()
        {
            return Connection.Query<studentANDcourse>("select * from studentsANDcourses").ToList();
        }

        [HttpPost("Students")]
        public string PostStudents(int id,string name)
        {
            Connection.Execute("insert into students values(@id,@name)",new {id=id,name=name});
            return "student qoshildi\nGetStudent orqali korishingiz mumkin!";
        }

        [HttpPost("Courses")]
        public string PostCourses(int id, string name)
        {
            Connection.Execute("insert into courses values(@id,@name)", new { id = id, name = name });
            return "course qoshildi\nGetCourse orqali korishingiz mumkin!";
        }

        [HttpPost("studentANDcourse")]
        public string PoststudentANDcourse(int studentId,int courseId)
        {
            Connection.Execute("insert into studentsANDcourses values (@studentId,@courseId)", new {studentId=studentId,courseId=courseId});
            return "malumot qoshildi \nGetstudentANDcourse orqali korishingiz mumkin";
        }
    }
}
