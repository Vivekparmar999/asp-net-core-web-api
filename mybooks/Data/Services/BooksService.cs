﻿using mybooks.Data.Models;
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

        public void AddBook(BookVM bookVM)
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
                Author = bookVM.Author,
                CoverUrl = bookVM.CoverUrl,
                //Here we assign current time
                DateAdded = DateTime.Now,

            };

            //In AppDbContext it will add in Books Table.
            _context.Books.Add(_book);
            _context.SaveChanges();

        }

        //It Will fetch all books from AppDbContext in Books Table in form of List
        public List<Book> GetAllBooks() => _context.Books.ToList();

        //Here n is parameter of book & it will check both are equal
        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);

    }

}