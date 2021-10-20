using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }

        //Navigation Properties   
        //Rel bet Book <---book author---> author 
        // so Book Id, Author Id, Book , Author

        public int BookId { get; set; }

        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
