using mybooks.Data.Models;
using mybooks.Data.Paging;
using mybooks.Data.ViewModels;
using mybooks.Excep;
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

        public List<Publisher> GetAllPublishers(string sortBy,  string searchString, int? pageNUmber) 
        {
         var allPublishers = _context.Publishers.OrderBy(n => n.Name).ToList();

            if (!string.IsNullOrEmpty(sortBy)) 
            {
                switch (sortBy) 
                {
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(searchString)) 
            {
                allPublishers = allPublishers.Where(n => n.Name.Contains(searchString,StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            //Paging 
            //By default 1 page contain 3 items
            int pageSize = 5;
            allPublishers = PaginatedList<Publisher>.Create(allPublishers.AsQueryable(), pageNUmber ?? 1, pageSize);
            return allPublishers;
        }
        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

        public PublisherwithBooksandAuthorsVM GetPublisherData(int publisherId) 
        {
            //We get Publisher Data pass to PublisherwithBooksandAuthorsVM
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherwithBooksandAuthorsVM()
                { 
                    //We know publisher Name
                    Name = n.Name,
                    //Publisher.book so passing book to BookAuthorVM
                    BookAuthors = n.Books.Select( n => new BookAuthorVM() {
                        //We know Book Name
                              BookName = n.Title,
                              //Book.authors.fullname
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
