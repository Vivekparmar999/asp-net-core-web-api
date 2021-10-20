﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //Navigation Properties
        //Rel bet Book <---book author---> author  List<BookAuthors>
        public List<Book_Author> Book_Authors { get; set; }

    }
}
