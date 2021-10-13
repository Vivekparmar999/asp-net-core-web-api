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


        [HttpGet("get-all-book")]
        public IActionResult GetAllBooks() {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        //It is best practiceto write id in {}
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }


        [HttpPut("update-book-by-id/{id}")]

        //Parameter id & Request Body
        public IActionResult UpdateBookById(int id, [FromBody] BookVM bookVM)
        {
            var updateBook = _booksService.UpdateBookById(id, bookVM);
            return Ok(updateBook);
        }


    }
}
