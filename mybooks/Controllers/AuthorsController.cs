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
    public class AuthorsController : ControllerBase
    {
        //Inject authorService
        private AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService) {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthors([FromBody] AuthorVM authorVM) 
        {
            _authorsService.AddAuthor(authorVM);
            return Ok();
        }

        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorwithBooks(int id) 
        {
            var response = _authorsService.GetAuthorWithBooks(id);
            return Ok(response);
        }

    }
}
