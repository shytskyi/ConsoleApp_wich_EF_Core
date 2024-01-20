using ConsoleApp_10.Models;

namespace ConsoleApp_10.Controller
{
    public class ComandCompany
    {
        public static void Create()
        {
            using (var db = new Context())
            {
                Console.Write("Please enter Name of company: ");
                string newName = Console.ReadLine();

                Company newCompany = new Company()
                {
                    Name = newName,
                };

                db.Companies.Add(newCompany);
                db.SaveChanges();
                Console.WriteLine("Success");
            }
        }

        public static void ReadAll()
        {
            using (var db = new Context())
            {
                var companies = db.Companies.ToList();
                Console.WriteLine("List of companies:");
                foreach (Company c in companies)
                    Console.WriteLine($"Name: {c.Name}");
            }
        }

        public static void Delete(int? id)
        {
            using (var db = new Context())
            {
                var company = db.Companies.FirstOrDefault(company => company.Id == id);
                if (company != null)
                {
                    db.Companies.Remove(company);
                    db.SaveChanges();
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("uncorect id");
            }
        }
    }
}
