namespace ConsoleApp_10.Models
{
    public class Company
    {
        public int Id { get; set; }                                     //PRIMARY KEY
        public string? Name { get; set; }
        public List<Employee> Employees { get; set; } = new();          //Navigation property
    }
}
