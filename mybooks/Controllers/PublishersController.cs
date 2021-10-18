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

    }
}
