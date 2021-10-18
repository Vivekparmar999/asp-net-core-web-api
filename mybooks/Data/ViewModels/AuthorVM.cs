using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorwithBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }

    }
}
