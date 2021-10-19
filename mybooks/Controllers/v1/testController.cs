using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Controllers.v1
{


    [ApiVersion("1.0")]
    [ApiVersion("1.2")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {

        //Method 1 - Query String Based Versioning
        //  ?api-version=1.0

        [HttpGet("test")]
        public IActionResult Get() {
            return Ok("This is Test 1");
        }

        //Method 2 - Write default version in startup.cs

        //Method 3 = Url based versioning
        //comment the route add version to it.
        //  api/v1/test/test


        //Method 4 - Http Header

        [HttpGet("test"),MapToApiVersion("1.0")]
        public IActionResult GetV10()
        {
            return Ok("This is Test V1.0");
        }


        [HttpGet("test"), MapToApiVersion("1.2")]
        public IActionResult GetV12()
        {
            return Ok("This is Test V1.2");
        }


        //Method 5 Content MediaType
        //startup.cs
        //header content-Type  text/plain;v=1.0
    }



}
