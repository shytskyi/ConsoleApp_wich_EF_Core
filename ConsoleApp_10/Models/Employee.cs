namespace ConsoleApp_10.Models
{
    public class Employee
    {
        public int Id { get; set; }             //PRIMARY KEY
        public string? Name { get; set; }
        public int CompanyId { get; set; }      // Foreign Key
                                                //there can also be another property name, but then there must be an attribute
                                                //or Fluent API example look at class Context
                                                //example attribute: 
                                                //[ForeignKey("CompanyInfoKey")]
                                                //public int CompanyInfoKey { get; set; }
        public Company? Company { get; set; }       //Navigation property
    }
}
