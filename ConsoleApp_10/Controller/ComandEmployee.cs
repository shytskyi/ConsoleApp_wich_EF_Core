using ConsoleApp_10.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_10.Controller
{
    public class ComandEmployee
    {
        public static void Create()
        {
            using (var db = new Context())
            {
                Console.Write("Please enter Name of eployee: ");
                string newName = Console.ReadLine();

                Employee newEmployee = new Employee()
                {
                    Name = newName,
                };

                db.Employees.Add(newEmployee);
                db.SaveChanges();
                Console.WriteLine("Success");
            }
        }

        public static void ReadAll()
        {
            using (var db = new Context())
            {
                var employees = db.Employees.Include(e => e.Company).ToList();            //Eager loading ( .Include().ThenInclude() )
                Console.WriteLine("List of employees:");
                foreach (Employee e in employees)
                    Console.WriteLine($"Name: {e.Name}, company: {e.Company?.Name}");
            }
        }

        public static void Delete(int? id)
        {
            using (var db = new Context())
            {
                var employee = db.Employees.FirstOrDefault(employee => employee.Id == id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("uncorect id");
            }
        }
    }
}
