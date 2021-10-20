using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        //Rel bet book & pub      Here only List<Book> Many rel
        public List<Book> Books { get; set; }

    }
}
