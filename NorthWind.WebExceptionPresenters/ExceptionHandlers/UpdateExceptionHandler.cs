using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionPresenters.ExceptionHandlers
{
    public class UpdateExceptionHandler : IExceptionHandler<UpdateException>
    {
        public ValueTask<ProblemDetails> Handle(
            UpdateException exception)
        {
            Dictionary<string, string> Extensions =
                new Dictionary<string, string>()
                {
                    {"entities", string.Join(",", exception.Entries)}
                };

            var ProblemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type =
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Error de actualización.",
                Detail = exception.Message
            };
            ProblemDetails.Extensions.Add("invalid-params", Extensions);
            return ValueTask.FromResult(ProblemDetails);
        }
    }

}
