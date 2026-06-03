using AlKarmahClub.Application.Common.Exceptions;
using AlKarmahClub.Application.Common.Models;
using AlKarmahClub.Domain.Exceptions;

namespace AlKarmahClub.Api.Middleware;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, message, errors) = exception switch
        {
            ValidationException validationException => (
                StatusCodes.Status400BadRequest,
                "Validation failed.",
                validationException.Errors),
            NotFoundException notFoundException => (
                StatusCodes.Status404NotFound,
                notFoundException.Message,
                new[] { notFoundException.Message }),
            UnauthorizedAccessAppException unauthorizedAccessException => (
                StatusCodes.Status401Unauthorized,
                unauthorizedAccessException.Message,
                new[] { unauthorizedAccessException.Message }),
            ForbiddenAccessException forbiddenAccessException => (
                StatusCodes.Status403Forbidden,
                forbiddenAccessException.Message,
                new[] { forbiddenAccessException.Message }),
            DomainException domainException => (
                StatusCodes.Status400BadRequest,
                domainException.Message,
                new[] { domainException.Message }),
            _ => (
                StatusCodes.Status500InternalServerError,
                "An unexpected error occurred.",
                new[] { "An unexpected error occurred." })
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            _logger.LogError(exception, "Unhandled exception occurred.");
        }
        else
        {
            _logger.LogWarning(exception, "Handled exception occurred.");
        }

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(ApiResponse<object>.Fail(errors, message));
    }
}
