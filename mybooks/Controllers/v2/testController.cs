using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Controllers.v2
{

    [ApiVersion("2.0")]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        //Method 1 - Query String Based Versioning

        [HttpGet("test")]
        public IActionResult Get() {
            return Ok("This is Test 2");
        }

        //Method 2 - Write default version in startup.cs

        //Method 3 = Url based versioning
        //comment the route add version to it.
        //  api/v2/test/test
    }

}
