using Microsoft.AspNetCore.Mvc;
using NorthWind.WebExceptionPresenters.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionPresenters.Filters
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new WebExceptionFilterAttribute(
                new ExceptionService()));
        }
    }
}
