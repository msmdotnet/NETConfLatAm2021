using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionPresenters.ExceptionHandlers
{
    public class ValidationExceptionHandler :
                IExceptionHandler<ValidationException>
    {
        public ValueTask<ProblemDetails> Handle(ValidationException exception)
        {
            Dictionary<string, string> Extensions =
                new Dictionary<string, string>();

            foreach (var Failure in exception.Errors)
            {
                if (Extensions.ContainsKey(Failure.PropertyName))
                {
                    Extensions[Failure.PropertyName] += " " + Failure.ErrorMessage;
                }
                else
                {
                    Extensions.Add(Failure.PropertyName, Failure.ErrorMessage);
                }
            }
            var ProblemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type =
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Error en los datos de entrada.",
                Detail = "Se encontró uno o más errores de validación de datos."
            };
            ProblemDetails.Extensions.Add("invalid-params", Extensions);
            return ValueTask.FromResult(ProblemDetails);
        }
    }

}
