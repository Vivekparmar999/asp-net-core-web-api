using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mybooks.ActionResults;
using mybooks.Data.Models;
using mybooks.Data.Services;
using mybooks.Data.ViewModels;
using mybooks.Excep;
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

        //Logging
        private readonly ILogger<PublishersController> _logger;

        public PublishersController(PublisshersService publisshersService, ILogger<PublishersController> logger)
        {
            _logger = logger;
            _publisshersService = publisshersService;
        }

        //Status Code Post - Created- 201
        [HttpPost("add-publisher")]
        public IActionResult AddPublishers([FromBody] PublisherVM publisherVM)
        {
            try
            {

                //From Controller _publisher will return
                var newPublisher = _publisshersService.AddPublisher(publisherVM);

                //Created (nameof(MethodName) ,ObjectValue )
                return Created(nameof(AddPublishers), newPublisher);

            }
            catch (PublisherNameException e)
            {
                return BadRequest($"{e.Message}, Publisher Name: {e.PublisherName}");
            }
            catch (Exception e) { return BadRequest(e.Message); }

        }


        //Status Code get - 404 or 200
        [HttpGet("get-publisher-by-id/{id}")]

        public IActionResult GetPublisherById(int id)
        {
            try
            {

                var _response = _publisshersService.GetPublisherById(id);
                if (_response != null)
                {
                    return Ok(_response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // Sorting , Filtering , paging
        
        //sorting ?sortBy=name_desc
        //Filtering ?searchString=pub
        //paging  ?pageNUmber=2
        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNUmber) 
        {

           // throw new Exception("THis is Exception thrown from GetAllPublishers()");

            try {

                _logger.LogInformation("This is a just log Info in GetAllPublishers()");
                var _result = _publisshersService.GetAllPublishers(sortBy,searchString,pageNUmber);
                return Ok(_result);
            } 
            catch (Exception e) {
                return BadRequest("Sorry, we could not load the publisher");
            }     
        }


        [HttpGet("get-publisher-books-with-authors/{id}")]

        public IActionResult GetPublisherData(int id)
        {
            try
            {

                var _reponse = _publisshersService.GetPublisherData(id);
                return Ok(_reponse);

            }
            catch (Exception e) { return BadRequest(e.Message); }

        }


        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {

            try
            {
                _publisshersService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
