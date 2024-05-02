using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LBSNEE.Application.Abstractions;

public class CustomValidationException : Exception
{
    public CustomValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> errors)
    {
        Errors = errors;
    }
    public IEnumerable<FluentValidation.Results.ValidationFailure> Errors { get; }
}
