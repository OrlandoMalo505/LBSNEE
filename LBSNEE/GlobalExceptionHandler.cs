using LBSNEE.Application.Abstractions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LBSNEE;

public partial class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, $"An exception happened, {exception.Message}");

        var exceptionDetails = GetExceptionDetails(exception);

        var problemDetails = new ProblemDetails
        {
            Status = exceptionDetails.Status,
            Type = exceptionDetails.Type,
            Title = exceptionDetails.Title
        };

        if (exceptionDetails.Errors is not null)
        {
            problemDetails.Extensions["errors"] = exceptionDetails.Errors;
        }

        httpContext.Response.StatusCode = exceptionDetails.Status;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static ExceptionDetails GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            CustomValidationException validationException => new ExceptionDetails(
                StatusCodes.Status400BadRequest,
                "Bad Request",
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                validationException.Errors),
            _ => new ExceptionDetails(
                StatusCodes.Status500InternalServerError,
                "Server Failure",
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                new List<Error> {
                    new Error
                    { Code = "Server Error", Description = "Internal Server Error" }
                })
        };
    }
}
