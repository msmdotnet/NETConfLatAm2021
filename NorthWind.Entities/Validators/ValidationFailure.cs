using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Validators
{
    public class ValidationFailure
    {
        public string PropertyName { get; }
        public string ErrorMessage { get; }
        public ValidationFailure(string propertyName, string errorMessage) =>
            (PropertyName, ErrorMessage) = (propertyName, errorMessage);
    }

}
