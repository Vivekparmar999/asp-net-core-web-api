using mybooks.Data.Models;
using mybooks.Data.ViewModels;
using mybooks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mybooks.Data.Services
{
    public class PublisshersService
    {
        private AppDbContext _context;

        public PublisshersService(AppDbContext context) {
            _context = context;
        }

        //Adding Method that Data to Database

        public Publisher AddPublisher(PublisherVM publisherVM)
        {

            if (StringStartWithNumber(publisherVM.Name)) throw new PublisherNameException("Name starts with number",publisherVM.Name);
            var _publisher = new Publisher()
            {
                Name = publisherVM.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

        public PublisherwithBooksandAuthorsVM GetPublisherData(int publisherId) 
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherwithBooksandAuthorsVM()
                { 
                    Name = n.Name,
                    BookAuthors = n.Books.Select( n => new BookAuthorVM() {
                              BookName = n.Title,
                              BookAuthors = n.Book_Authors.Select( n=> n.Author.FullName).ToList()
                    }).ToList()
                }
                ).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);

            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else {

                throw new Exception($"The publisher with id: {id} does not exist");

            }
        }


        private bool StringStartWithNumber(string name) => (Regex.IsMatch(name,@"^\d"));
    }
}
