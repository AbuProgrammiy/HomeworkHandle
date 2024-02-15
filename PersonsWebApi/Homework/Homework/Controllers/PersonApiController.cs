using Microsoft.AspNetCore.Mvc;
using Homework.Models;
using Npgsql;
using System.Text;
using Dapper;

namespace Homework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonApiController : ControllerBase
    {
        public PersonApiController()
        {
            Connection=new NpgsqlConnection(connectionString);
            Connection.Open();
            StartUp();
        }
//Shunchaki connection stringni ozizga moslab qoysangiz kifoya)
        public string connectionString = "Server=localhost;Port=5432;Database=Homework;User Id=postgres;Password=root";
        public NpgsqlConnection Connection;
        public StringBuilder query = new StringBuilder();

        private void StartUp()
        {
            try
            {
                query = new StringBuilder("create table Persons(id serial,name varchar(255),age int)");
                Connection.Execute(query.ToString());
                query = new StringBuilder("insert into Persons (name,age) values" +
                                         "('Abdukholiq',23)," +
                                         "('Ozod',21)," +
                                         "('Ibrohim',22)," +
                                         "('Nuriddin',24);");
                Connection.Execute(query.ToString());
            }
            catch { }
        }

        [HttpGet]
        public List<Person> GetAll()
        {
            query = new StringBuilder("select * from Persons");
            List<Person> list = new List<Person>();
            list = Connection.Query<Person>(query.ToString()).ToList();
            return list;
        }

        [HttpPost]
        public string Create(string name,int age)
        {
            query = new StringBuilder("insert into Persons(name, age) values(@name,@age)");
            Connection.Execute(query.ToString(), new { name = name, age = age });
            return "Ma'lumot qoshildi\nGet orqali koring!";
        }

        [HttpPut]
        public string UpdateAll(int qaysi_id_dagi_person,int id,string name,int age)
        {
            query = new StringBuilder("update Persons set id=@id,name=@name,age=@age where id=@qaysi;");
            Connection.Execute(query.ToString(), new {id=id, name=name, age = age ,qaysi=qaysi_id_dagi_person});
            return "Ozgartirildi\nGet orqali koring!";
        }

        [HttpPatch]
        public string UpdateOne(int qaysi_id_dagi_person,string name)
        {
            query = new StringBuilder("update Persons set name=@name where id =@qaysi");
            Connection.Execute(query.ToString(), new {name=name, qaysi=qaysi_id_dagi_person });
            return "Ozgartirildi\nGet orqali koring";
        }

        [HttpDelete]
        public string Delete(int qaysi_id_dagi_persons)
        {
            query = new StringBuilder("delete from persons where id=@id");
            Connection.Execute(query.ToString(), new { id = qaysi_id_dagi_persons });
            return "Ochirildi\nGet orqali koring!";
        }
    }
}
