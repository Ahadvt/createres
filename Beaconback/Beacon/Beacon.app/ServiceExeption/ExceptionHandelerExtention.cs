using Beacon.service.Exeptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beacon.app.ServiceExeption
{
    public static class ExceptionHandelerExtention
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = 500;
                    string msg = "Internal server error!";

                    if (contextFeature != null)
                    {
                        msg = contextFeature.Error.Message;

                        if (contextFeature.Error is ItemNotFoundExeption)
                            statusCode = 404;
                    }

                    context.Response.StatusCode = statusCode;

                    string responseStr = JsonConvert.SerializeObject(new
                    {
                        code = statusCode,
                        message = msg
                    });

                    await context.Response.WriteAsync(responseStr);
                });
            });

        }
    }
}
