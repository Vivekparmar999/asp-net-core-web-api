using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mybooks.Data.Services;
using mybooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  BooksController : ControllerBase
    {

        //adding Service dependency to controller
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
            //intialize the value of Booksservice
        }


        //creating EndPoint
        
        
        //[HttpPost]
        //    /api/Books

        //Custom EndPoint
        //    /api/Books/add-book
        [HttpPost("add-book")]

        public IActionResult AddBook([FromBody] BookVM bookVM) 
        {
            //Adding bookViewModel to BookService.
            _booksService.AddBook(bookVM);
            return Ok();

        }

    }
}
