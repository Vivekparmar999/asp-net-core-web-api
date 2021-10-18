using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public PublishersController(PublisshersService publisshersService) {
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
            catch (PublisherNameException e) {
                return BadRequest($"{e.Message}, Publisher Name: {e.PublisherName}");
            }
            catch (Exception e) { return BadRequest(e.Message); }



        }


        //Status Code get - 404 or 200
        [HttpGet("get-publisher-by-id/{id}")]

        public IActionResult GetPublisherById(int id) 
        {

            throw new System.Exception("This exception handled by middleWare");


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


        [HttpGet("get-publisher-books-with-authors/{id}")]

        public IActionResult GetPublisherData(int id)
        {
            try {

                var _reponse = _publisshersService.GetPublisherData(id);
                return Ok(_reponse);

            }
            catch(Exception e) { return BadRequest(e.Message); }

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
