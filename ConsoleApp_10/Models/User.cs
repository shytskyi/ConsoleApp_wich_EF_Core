using System.ComponentModel.DataAnnotations;

namespace ConsoleApp_10.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Surname { get; set; }   // Required in Fulent Api, watch context
        public int Age { get; set; }
    }
}
