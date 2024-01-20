using ConsoleApp_10.Models;

namespace ConsoleApp_10.Controller
{
    public class ComandBook
    {
        public static void Create()
        {
            using (var db = new Context())
            {
                Console.Write("Please enter Name of book: ");
                string newName = Console.ReadLine();

                Book newUser = new Book()
                {
                    Name = newName,
                };

                db.Books.Add(newUser);
                db.SaveChanges();
                Console.WriteLine("Success");
            }
        }

        public static void ReadAll()
        {
            using (var db = new Context())
            {
                var books = db.Books.ToList();
                Console.WriteLine("List of books:");
                foreach (Book u in books)
                    Console.WriteLine($"Id - {u.Id}, Name - {u.Name}");
            }
        }

        public static void Delete(int? id)
        {
            using (var db = new Context())
            {
                var book = db.Books.FirstOrDefault(book => book.Id == id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("uncorect id");
            }
        }
    }
}
