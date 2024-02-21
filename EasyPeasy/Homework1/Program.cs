using Homework1;
using System.Text.Json;
namespace Homework1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Buxalter> buxalters = new List<Buxalter>()
            {
                new Buxalter
                {
                    Id = 1,
                    Name = "Abduxoliq",
                    ProgrammingLanguageId = 1,
                },
                new Buxalter
                {
                    Id = 2,
                    Name = "Abdulloh",
                    ProgrammingLanguageId = 0,
                },
                new Buxalter
                {
                    Id = 3,
                    Name = "Otabek",
                    ProgrammingLanguageId = 2,
                },
                new Buxalter
                {
                    Id = 4,
                    Name = "Izzat",
                    ProgrammingLanguageId = 0,
                },
            };

            IEnumerable<ProgrammingLanguage> programmingLanguages = new List<ProgrammingLanguage>()
            {
                new ProgrammingLanguage
                {
                    Id= 1,
                    Name= "C#"
                },
                new ProgrammingLanguage
                {
                    Id= 2,
                    Name= "Python"
                },
                new ProgrammingLanguage
                {
                    Id= 3,
                    Name= "Rust"
                },
                new ProgrammingLanguage
                {
                    Id= 4,
                    Name= "C"
                },
            };

            //Programmingni biladigan dasturchilarni olish
            IEnumerable<Buxalter> ProgrammerBuxalters = buxalters.Where(b=>b.ProgrammingLanguageId!=0);
            ProgrammerBuxalters = buxalters.Join(programmingLanguages,
                buxalter => buxalter.ProgrammingLanguageId,
                programmingLanguage => programmingLanguage.Id,
                (buxalter, programmingLanguage) => buxalter);

            string data =JsonSerializer.Serialize(ProgrammerBuxalters,new JsonSerializerOptions() { WriteIndented=true});
            Console.WriteLine(data+"\n"+new string('-',50));
            
            // C# biladigan buxaltrlar
            IEnumerable<Buxalter> DotNetProgrammers = buxalters.Where(b => b.ProgrammingLanguageId == 1);
            data=JsonSerializer.Serialize(DotNetProgrammers,new JsonSerializerOptions() { WriteIndented=true});
            Console.WriteLine(data);
        }
    }
}
