//juda ham smooth ishlamoqda

using Npgsql;
namespace SupportDars
{
    public class Hellogram
    {
        public Hellogram()
        {
            Console.CursorVisible = false;
            Connection.Open();
            StartUp();
            Enterence();

        }
        // databasalirzi ozizga moslavolishiz kere
        public const string CONNECTIOSTRING = "Server=localhost;Port=5432;Database=Homework;User Id=postgres;Password=root;";
        public NpgsqlConnection Connection = new NpgsqlConnection(CONNECTIOSTRING);
        public NpgsqlCommand Command;
        ConsoleKeyInfo key;
        public string userName;
        public string password;

        public void StartUp()
        {
            //Agar progrm birinchi marta ishlatayotgan bolsa tablelar create boladi
            Command = new NpgsqlCommand("create table if not exists Users(id serial,username varchar(255),password varchar(255));", Connection);
            Command.ExecuteNonQuery();
            Command = new NpgsqlCommand("create table if not exists Messages(from_username varchar(255),message text,to_username varchar(255));", Connection);
            Command.ExecuteNonQuery();
        }

        public void Enterence()
        {
            Console.Clear();
            int i = 0;
            string[] choice = { "Log in", "Registration" };
            Console.ForegroundColor = ConsoleColor.DarkGray;

            while (true)
            {
                for (int j = 0; j < choice.Length; j++)
                {
                    if (j == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(choice[j]);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else
                        Console.WriteLine(choice[j]);
                }
                key = Console.ReadKey();
                if (key.KeyChar == '\u000d')
                    break;
                i = (i + 1) % choice.Length;
                Console.Clear();
            }
            if (i == 1)
                Registration();
            else
                LogIn();
        }

        public void Registration()
        {
            Console.Clear();
            Console.CursorVisible = true;
            again:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Usernameni kiriting: ");
            userName = Console.ReadLine();
            Console.Write("Passwordini kiritng: ");
            password = Console.ReadLine();

            //username oldindan mavjud yoki yoqliga tekshirish
            Command = new NpgsqlCommand("select username from users", Connection);
            NpgsqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0) == userName)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username allaqachon band qilingan");
                    reader.Close();
                    goto again;
                }
            }
            reader.Close();

            //registratsiyadan otqazish                                                                      hashlash: vvvvvvvv
            Command = new NpgsqlCommand($"insert into users(username,password) values ('{userName}','{HashingAlgorithm(password)}');", Connection);
            Command.ExecuteNonQuery();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nRegistratsiyadan muvofaqayatli otdingiz!");
            Thread.Sleep(1500);
            Enterence();
        }

        public void LogIn()
        {
            Console.Clear();
            Console.CursorVisible = true;

        again:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Usernameni kiriting: ");
            userName = Console.ReadLine();
            Console.Write("Passwordini kiritng: ");
            password = Console.ReadLine();

            //username oldindan mavjud yoki yoqliga tekshirish
            Command = new NpgsqlCommand("select username,password from users", Connection);
            NpgsqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                                            /* UnHashing vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv*/
                if (reader.GetString(0) == userName && UnHashingAlgorithm( reader.GetString(1)) == password)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\nAccount muvafaqiyatli LOGIN qildingiz");
                    reader.Close();
                    Thread.Sleep(1500);
                    MessageManagment();
                    return;
                }
            }
            reader.Close();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Password yoki Username xato");
            Thread.Sleep(1000);
            Enterence();
        }

        public void MessageManagment()
        {
            Console.Clear();
            Console.CursorVisible = false;
            string[] choice = { "Message jonatish", "Kelgan messagelarni korish" };
            int i = 0;
            while (true)
            {
                for (int j = 0; j < choice.Length; j++)
                {
                    if (j == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(choice[j]);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else
                        Console.WriteLine(choice[j]);
                }
                key = Console.ReadKey();
                if (key.KeyChar == '\u000d')
                    break;
                i = (i + 1) % choice.Length;
                Console.Clear();
            }
            if (i == 0)
                SendMessag();
            else
                ViewMessages();
        }

        public void SendMessag()
        {
            List<string> users = new List<string>();
            string message;
            int i = 0;
            Command = new NpgsqlCommand("select username from users", Connection);
            NpgsqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                if (userName != reader.GetString(0))
                    users.Add(reader.GetString(0));
            }
            reader.Close();

            if (users.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Message jonata olmaysiz chunki szdan boshqa odam registratsiyadan otmagan");
                Thread.Sleep(2000);
                Enterence();
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Kimga jo'natmoqchisiz: ");
                Console.ForegroundColor = ConsoleColor.DarkGray;

                for (int j = 0; j < users.Count; j++)
                {
                    if (j == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(users[j]);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else
                        Console.WriteLine(users[j]);
                }
                key = Console.ReadKey();
                if (key.KeyChar == '\u000d')
                    break;
                else if (key.Key == ConsoleKey.DownArrow && i < users.Count - 1)
                    i++;
                else if (key.Key == ConsoleKey.UpArrow && i > 0)
                    i--;
            }
            Console.Clear();
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Xabar: ");
            message = Console.ReadLine()!;
            Command = new NpgsqlCommand($"insert into messages values('{userName}','{message}','{users[i]}');", Connection);
            Command.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Message jonatildi!");
            Thread.Sleep(1000);
            Enterence();
        }

        public void ViewMessages()
        {
            Command = new NpgsqlCommand($"select * from messages where to_username='{userName}'", Connection);
            NpgsqlDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"\nKimdan: {reader.GetString(0)}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Xabar: {reader.GetString(1)}");
            }
            reader.Close();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("OK:");
            Console.ReadKey();
            Enterence();
        }

        public string HashingAlgorithm(string password)
        {
            int sezar = 5;
            string result = "";
            foreach(char c in password)
            {
                result += (char)(Convert.ToInt32(c) + sezar);
            }
            return result;
        }
        public string UnHashingAlgorithm(string password)
        {
            int sezar = 5;
            string result = "";
            foreach (char c in password)
            {
                result += (char)(Convert.ToInt32(c) - sezar);
            }
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Hellogram Start = new Hellogram();
        }
    }
}
