using System.Text;

namespace NorthWind.Entities.Validators
{
#nullable disable
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; }

        public ValidationException() { }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception innerException) :
            base(message, innerException)
        { }

        public ValidationException(IEnumerable<ValidationFailure> errors) =>
            Errors = errors;

        public override string ToString()
        {
            string Result = base.Message;
            if (Errors != null && Errors.Any())
            {
                StringBuilder Builder = new StringBuilder();
                foreach (var Error in Errors)
                {
                    Builder.AppendLine(
                        $"{Error.PropertyName}: {Error.ErrorMessage}");
                }
                Result = Builder.ToString();
            }
            return Result;
        }
        public override string Message
        {
            get
            {
                return ToString();
            }
        }

    }
}
