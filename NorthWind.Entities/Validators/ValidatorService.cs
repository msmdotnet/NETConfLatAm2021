using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Validators
{
    public class ValidatorService<Model> : IValidatorService<Model>
    {
        public void Validate(
            Model model, IEnumerable<IValidator<Model>> validators,
            IApplicationStatusLogger logger = null!)
        {
            var Failures = validators
                .Select(v => v.Validate(model))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (Failures.Any())
            {
                var Exception = new ValidationException(Failures);
                if (logger != null)
                {
                    logger.Log($"Error en la entrada de datos.");
                    logger.Log(Exception.Message);
                }
                throw Exception;
            }
        }

    }
}
