using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_10.Models
{
    public class Country
    {
        //[Column("country_id")]                           -> rename in DB (prop Ident in model Country = column country_id in DB). Fulent Api in Context
        //[Key]                                            -> Primery Key is property Ident. Fulent Api in Context
        public int Ident { get; set; }

        //[MaxLength(50)]                                 -> Atribute constraint max lenght for Name. Fulent Api in Context
        public string? Name { get; set; }
        public int Age { get; set; }                      //-> intresting constraint watch Fulent Api in Context

        //[NotMapped]                                      -> If you do not want Mapped this property to DB
        public string? NoPropertyRequired { get; set; }    // or see Context (Fluent Api)
    }
}
