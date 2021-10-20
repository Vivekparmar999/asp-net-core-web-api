using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using mybooks.Data.ViewModels;
using mybooks.Execp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Excep
{
    public static class ExceptionMiddlewareExtensions
    {

        public static void ConfigureBuildInExceptionHandler(this IApplicationBuilder app,ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(

                appError => appError.Run(
                    async context =>
                    {

                        var loggger = loggerFactory.CreateLogger("ConfigureBuildInExceptionHandler");
                        context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        var contextRequest = context.Features.Get<IHttpRequestFeature>();

                        if (contextFeature != null)
                        {

                            var errorVMString = new ErrorVM() {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message,
                                Path = contextRequest.Path

                            }.ToString();

                            loggger.LogError(errorVMString);

                            await context.Response.WriteAsync(errorVMString);

                        }

                    }
                    )
                ); ;
        }


        public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

    }

}
