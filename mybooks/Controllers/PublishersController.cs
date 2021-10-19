using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public PublishersController(PublisshersService publisshersService)
        {
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



        //Specific Return  -  Data 
        [HttpGet("get-publisher-by-id-specific-action-return/{id}")]

        public Publisher GetPublisherByIdSpecificActionReturn(int id)
        {

            var _response = _publisshersService.GetPublisherById(id);

            if (_response != null)
            {

                return _response;
            }
            else
            {

                return null;
            }
        }


        //IActionResult -- Return only statusCode
        [HttpGet("get-publisher-by-id-IActionResult/{id}")]

        public IActionResult GetPublisherByIdIActionReturn(int id)
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


        //ActionResult<Type>  --  Return any stausCode or Data
        [HttpGet("get-publisher-by-id-ActionResult/{id}")]

        public ActionResult<Publisher> GetPublisherByIdActionReturn(int id)
        {


            try
            {

                var _response = _publisshersService.GetPublisherById(id);

                if (_response != null)
                {
                    return _response;

                }
                else
                {
                    return NotFound();

                }


            }
            catch (Exception e) { return BadRequest(e.Message); }

        }


        //CustomActionResult

        [HttpGet("get-publisher-by-id-CustomActionResult/{id}")]

        public CustomActionResult GetPublisherByIdCustomActionReturn(int id)
        {

            var _response = _publisshersService.GetPublisherById(id);

            if (_response != null)
            {
                var _responseObj = new CustomActionResultVM()
                {
                    Publisher = _response
                };

                return new CustomActionResult(_responseObj);
            }
            else
            {

                var _responseObj = new CustomActionResultVM()
                {
                    Exception = new Exception("This is coming from publisher custom controller")
                };

                return new CustomActionResult(_responseObj);

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
