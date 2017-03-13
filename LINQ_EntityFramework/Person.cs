using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_EntityFramework
{
    public class Person // POCO
    {
        public Person()
        {
            Cars = new List<Car>();
        }
        // no need for[Key] to identify the Primary
        public int PersonId { get; set; } // primary key // every entity MUST have a Primary Key
        public string First { get; set; }
        public string Last { get; set; }
        public string Suffix { get; set; }

        [NotMapped]
        public String FullName { get { return $"{Last}, {First}"; } }

        public virtual List<Car> Cars { get; set; }
    }
}