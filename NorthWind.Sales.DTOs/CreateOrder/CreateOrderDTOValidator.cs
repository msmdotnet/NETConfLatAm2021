using FluentValidation;
using NorthWind.Entities.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.DTOs.CreateOrder
{
    public class CreateOrderDTOValidator
            : AbstractValidator<CreateOrderDTO>,
            Entities.Validators.IValidator<CreateOrderDTO>
    {
        public CreateOrderDTOValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage(
                "Debe proporcionar el identificador del cliente.")
                .Length(5)
                .WithMessage("La longitud del identificador debe ser 5.");


            RuleFor(c => c.ShipAddress).NotEmpty().WithMessage(
                "Debe proporcionar la dirección de envío.")
                .MaximumLength(60).WithMessage(
                "La longituda máxima de la dirección es 60");

            RuleFor(c => c.ShipCity).NotEmpty().WithMessage(
                "Debe proporcionar la ciudad de envío.")
                .MinimumLength(3).WithMessage(
                "Debe especificar al menos 3 caracteres del nombre de la ciudad.")
                .MaximumLength(15).WithMessage(
                "La longitud máxima de la ciudad es 15");

            RuleFor(c => c.ShipCountry).NotEmpty().WithMessage(
                "Debe proporcionar el país de envío.")
                .MinimumLength(3).WithMessage(
                "Debe especificar al menos 3 caracteres del nombre del País.")
                .MaximumLength(15).WithMessage(
                "La longitud máxima del país es 15");

            RuleFor(c => c.ShipPostalCode).MaximumLength(10)
                .WithMessage("La longitud máxima del código postal es 10.");

            RuleFor(c => c.OrderDetails).Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Debe especificar los productos de la orden.")
                .NotEmpty()
                .WithMessage("Debe especificar al menos un producto de la orden.");

            RuleForEach(c => c.OrderDetails)
                .SetValidator(new CreateOrderDetailDTOValidator());
        }

        ValidationResult Entities.Validators.IValidator<CreateOrderDTO>
            .Validate(CreateOrderDTO instance)
        {
            var Result = Validate(instance);
            return new ValidationResult(
                Result.Errors?
                    .Select(e =>
                        new ValidationFailure(e.PropertyName, e.ErrorMessage)));
        }
    }


}
