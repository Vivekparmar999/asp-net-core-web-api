using mybooks.Data.Models;
using mybooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data.Services
{
    public class BooksService
    {

        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookVM bookVM)
        {
            //passing BookVM Data to _book (Book Class)
            var _book = new Book()
            {
                //Book = BookVM
                Title= bookVM.Title,
                Description = bookVM.Description,
                Isread = bookVM.Isread,
                //For null 
                //IF its not null then its value or null
                DateRead = bookVM.Isread ? bookVM.DateRead.Value:null,
                Genre = bookVM.Genre,
                CoverUrl = bookVM.CoverUrl,
                //Here we assign current time
                DateAdded = DateTime.Now,
                PublisherId = bookVM.publisherId
            };

            //In AppDbContext it will add in Books Table.
            _context.Books.Add(_book);
            _context.SaveChanges();

            //We will add rel of book <---> bookAuthor to author table

            foreach (var id in bookVM.AuthorsIds) {
                var _book_author = new Book_Author()
                {

                    BookId = _book.Id,
                    AuthorId = id
                };

                _context.BookAuthors.Add(_book_author);
                _context.SaveChanges();
            }
         }

        //It Will fetch all books from AppDbContext in Books Table in form of List
        public List<Book> GetAllBooks() => _context.Books.ToList();

        //Here n is parameter of book & it will check both are equal
        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);


        //Update the Book
        public Book UpdateBookById(int bookId, BookVM bookVM)
        {

            //check if book exist or not in Database
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);

            if (_book != null)
            {

                _book.Title = bookVM.Title;
                _book.Description = bookVM.Description;
                _book.Isread = bookVM.Isread;
                _book.DateRead = bookVM.Isread ? bookVM.DateRead.Value : null;
                _book.Genre = bookVM.Genre;
               //_book.Author = bookVM.Author;
                _book.CoverUrl = bookVM.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }


        //Delete the Book
        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null) {

                //Remove Query from Table
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }

    }

}
