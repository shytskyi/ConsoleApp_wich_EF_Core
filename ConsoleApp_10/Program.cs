using ConsoleApp_10.Controller;

namespace ConsoleApp_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comands.Start(true);
            Console.WriteLine("Commands for users:");
            Console.WriteLine("Commands: C (Creat), R (Read all), R1 (Read By Id), U (update), D (Delete) and EX (exit)");
            Console.WriteLine("Commands for books:");
            Console.WriteLine("Commands: CC (Creat), RR (Read all), DD (Delete) and EX (exit)");
            Console.WriteLine("Commands for companies:");
            Console.WriteLine("Commands: CCC (Creat), RRR (Read all), DDD (Delete) and EX (exit)");
            Console.WriteLine("Commands for employees:");
            Console.WriteLine("Commands: CCCC (Creat), RRRR (Read all), DDDD (Delete) and EX (exit)");
            bool exit = true;
            do
            {
                int? id;
                Console.Write(">");
                var command = Console.ReadLine();
                bool a = command != "CCC";
                bool b = command != "RRR";
                bool c = command != "DDD";
                bool d = command != "C";
                bool e = command != "R";
                bool f = command != "CC";
                bool g = command != "RR";
                bool k = command != "CCCC";
                bool l = command != "RRRR";
                bool j = command != "DDDD";
                if (d && e && f && g && a && b && c && k && l && j && command != "EX")
                {
                    try
                    {
                        Console.WriteLine("Please enter id");
                        id = Convert.ToInt32(Console.ReadLine());
                    }
                    catch 
                    {
                        id = null;
                    }
                }
                else
                {
                    id = null;
                }
                switch (command)
                {
                    case "CCCC":
                        ComandEmployee.Create();
                        break;
                    case "RRRR":
                        ComandEmployee.Create();
                        break;
                    case "DDDD":
                        ComandEmployee.Create();
                        break;
                    case "CCC":
                        ComandCompany.Create();
                        break;
                    case "RRR":
                        ComandCompany.Create();
                        break;
                    case "DDD":
                        ComandCompany.Create();
                        break;
                    case "CC":
                        ComandBook.Create();
                        break;
                    case "RR":
                        ComandBook.ReadAll();
                        break;
                    case "DD":
                        ComandBook.Delete(id);
                        break;
                    case "C":
                        Comands.Create();
                        break;
                    case "R":
                        Comands.ReadAll();
                        break;
                    case "R1":
                        Comands.ReadById(id);
                        break;
                    case "U":
                        Comands.Update(id);
                        break;
                    case "D":
                        Comands.Delete(id);
                        break;
                    case "EX":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            } while (exit);
        }
    }
}