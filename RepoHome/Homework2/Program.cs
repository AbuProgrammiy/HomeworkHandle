
using Homework2.RepoManagment.IRepository;
using Homework2.RepoManagment.Repository;
using Homework2.Services.ShowStudentsDish;

namespace Homework2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IBuffetRepository, BuffetRepository>();
            builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
            builder.Services.AddScoped<IShowAllStudentsDishService, ShowAllStudentsDishService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
