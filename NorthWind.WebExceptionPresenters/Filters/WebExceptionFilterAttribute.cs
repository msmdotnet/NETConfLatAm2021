using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NorthWind.WebExceptionPresenters.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionPresenters.Filters
{
    public class WebExceptionFilterAttribute : ExceptionFilterAttribute
    {
        // Diccionario de parejas Excepción-Manejador 
        readonly ExceptionService Service;

        public WebExceptionFilterAttribute(ExceptionService service) =>
               Service = service;

        // Invocado cuando una acción lanza una excepción
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var ProblemDetails = await Service.Handle(context.Exception);

            // Establecer el valor IActionResult a devolver
            context.Result = new ObjectResult(ProblemDetails)
            {
                StatusCode = ProblemDetails.Status
            };

            // Indicar que se ha manejado la excepción.
            context.ExceptionHandled = true;

            await base.OnExceptionAsync(context);
        }
    }

}
