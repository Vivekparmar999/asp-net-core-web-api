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
    public class PublishersController : ControllerBase
    {
        //Inject authorService
        private PublisshersService _publisshersService;

        public PublishersController(PublisshersService publisshersService) {
            _publisshersService = publisshersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublishers([FromBody] PublisherVM publisherVM) 
        {
            _publisshersService.AddPublisher(publisherVM);
            return Ok();
        }


        [HttpGet("get-publisher-books-with-authors/{id}")]

        public IActionResult GetPublisherData(int id)
        {
            var _reponse = _publisshersService.GetPublisherData(id);
            return Ok(_reponse);
        }


        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id) 
        {
            _publisshersService.DeletePublisherById(id);
            return Ok();
        }
    }
}
