using ConsoleApp_10.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ConsoleApp_10
{
    public class Comands
    {
        public static bool Start(bool onlyIfNoDatabase)
        {
            using (var db = new Context())
            {
                if (onlyIfNoDatabase && (db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return false;

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            return true;
        }
        public static void Create()
        {
            using (var db = new Context())
            {
                Console.Write("Please enter Name: ");
                string newName = Console.ReadLine();
                Console.Write("Please enter Surname: ");
                string newSurname = Console.ReadLine();
                Console.Write("Please enter Age: ");
                int newAge = Convert.ToInt32(Console.ReadLine());

                User newUser = new User
                {
                    Name = newName,
                    Surname = newSurname,
                    Age = newAge
                };

                db.Users.Add(newUser);
                db.SaveChanges();
                Console.WriteLine("Success");
            }
        }

        public static void ReadById(int? id)
        {
            using (var db = new Context())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == id);
                if (user == null)
                    Console.WriteLine("uncorect id");
                else
                    Console.WriteLine($"Id - {user.Id}, Name - {user.Name}, Surname - {user.Surname}, Age - {user.Age}");
            }
        }
        public static void ReadAll()
        {
            using (var db = new Context())
            {
                var users = db.Users.ToList();
                Console.WriteLine("List of users:");
                foreach (User u in users)
                    Console.WriteLine($"Id - {u.Id}, Name - {u.Name}, Surname - {u.Surname}, Age - {u.Age}");
            }
        }
        public static void Update(int? id)
        {
            using (var db = new Context())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == id);
                if (user != null)
                {
                    Console.Write("Please enter Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Please enter Surname: ");
                    string newSurname = Console.ReadLine();
                    Console.Write("Please enter Age: ");
                    int newAge = Convert.ToInt32(Console.ReadLine());

                    user.Name = newName;
                    user.Surname = newSurname;
                    user.Age = newAge;
                    db.Users.Update(user);

                    db.SaveChanges();
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("uncorect id");
            }
        }
        public static void Delete(int? id)
        {
            using (var db = new Context())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("uncorect id");
            }
        }

    }
}
