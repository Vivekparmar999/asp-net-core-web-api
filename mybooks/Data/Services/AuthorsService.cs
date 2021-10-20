using mybooks.Data.Models;
using mybooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context) {
            _context = context;
        }

        //Adding Method that Data to Database

        public void AddAuthor(AuthorVM authorVM)
        {
            var _author = new Author()
            {
                FullName = authorVM.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorwithBooksVM GetAuthorWithBooks(int authorId) 
        {
            //We want AuthorName & bookName
            //Where() => we get author and pass in AuthorwithBooksVM
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorwithBooksVM()
            {
                FullName = n.FullName,
                // Map automatically  author<---Book_author--->book
                
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }
    }
}
