using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionPresenters.ExceptionHandlers
{
    interface IExceptionHandler<ExceptionType>
    {
        ValueTask<ProblemDetails> Handle(ExceptionType exception);
    }
}
