using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mybooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.ActionResults
{
    public class CustomActionResult : IActionResult
    {
        private readonly CustomActionResultVM _result;

        public CustomActionResult(CustomActionResultVM result)
        {
            _result = result;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            //If we have action then use that message or If exception doesnot have data use publisher
            var objectResult = new ObjectResult(_result.Exception ?? _result.Publisher as object)
            {
                StatusCode = _result.Exception != null ? StatusCodes.Status500InternalServerError : StatusCodes.Status200OK
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
