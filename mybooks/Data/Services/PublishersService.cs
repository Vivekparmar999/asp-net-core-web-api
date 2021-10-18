using mybooks.Data.Models;
using mybooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddPublisher(PublisherVM publisherVM)
        {
            var _publisher = new Publisher()
            {
                Name = publisherVM.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
