using Dapper;
using Homework2.Entities.DTOs;
using Homework2.Models;
using Homework2.RepoManagment.IRepository;
using Npgsql;

namespace Homework2.RepoManagment.Repository
{
    public class BuffetRepository : IBuffetRepository
    {
        public NpgsqlConnection Connection;
        public string connectionString = "Server=localhost;Port=5432;Database=Homework;User Id=postgres;Password=root;";
        public BuffetRepository()
        {
            Connection = new NpgsqlConnection(connectionString);
            try
            {
                Connection.Execute("create table Buffet(id serial,DishName varchar(255),Description text);");
                Connection.Execute("insert into Buffet(dishName,description) values('Spagetti','Talabalrning yoqimli tushligi')," +
                                                            "('Makaron','Juda mazali va goshlari kop')," +
                                                            "('Hotlanch','Pul Ekonom qilish uchun');");

            }
            catch { }
        }

        public string CreateBuffet(BuffetDTO buffetDto)
        {
            string query = "insert into buffet(dishName,description) values(@DishName,@Description);";
            BuffetDTO parametrs = new BuffetDTO()
            {
                DishName = buffetDto.DishName,
                Description = buffetDto.Description,
            };
            Connection.Execute(query, parametrs);
            return "Ma'lumot qo'shildi\n GetAll orqali ko'rishingiz mumkin!";
        }

        public IEnumerable<Buffet> GetAllBuffet()
        {
            string query = "select * from buffet;";
            return Connection.Query<Buffet>(query).ToList();
        }

        public string UpdateBuffet(int id,BuffetDTO buffetDto)
        {
            string query = "update buffet set dishName=@DishName,description=@Description where id=@id";

            int i = Connection.Execute(query, new
            {
                id = id,
                DishName= buffetDto.DishName,
                Description = buffetDto.Description
            });
            if (i == 0)
                return $"{id} id li Buffet mavjud emas)";
            else
                return "Buffet Update qilindi";
        }

        public string DeleteBuffet(int id)
        {
            string query = "delete from buffet where id = @id";
            int i = Connection.Execute(query, new { id = id });
            if (i == 0)
                return $"{id} id li Buffet mavjud emas)";
            else
                return "Ochib ketti bechora";
        }
    }
}
