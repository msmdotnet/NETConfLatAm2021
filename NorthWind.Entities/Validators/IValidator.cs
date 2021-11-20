using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Validators
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T instance);
    }
}
