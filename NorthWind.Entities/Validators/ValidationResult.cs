using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Validators
{
    public class ValidationResult
    {
        public IEnumerable<ValidationFailure> Errors { get; }
        public ValidationResult(IEnumerable<ValidationFailure> errors) =>
            Errors = errors;

        public virtual bool IsValid =>
            Errors == null || !Errors.Any();
    }

}
