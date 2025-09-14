namespace SilentMike.Gielda.Commision.WebApi.Handlers;

using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using SilentMike.Gielda.Commision.Application.Common.Exceptions;
using SilentMike.Gielda.Commision.Domain.Common.Exceptions;

internal sealed class ExceptionsHandler : IExceptionHandler
{
    private const string DEFAULT_TITLE = "An error occurred";

    private readonly IProblemDetailsService problemDetailsService;

    public ExceptionsHandler(IProblemDetailsService problemDetailsService)
        => this.problemDetailsService = problemDetailsService;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var (statusCode, title) = exception switch
        {
            ValidationException validationException => ((int)HttpStatusCode.BadRequest, validationException.Code),
            ApplicationException applicationException => ((int)HttpStatusCode.InternalServerError, applicationException.Code),
            DomainException domainException => ((int)HttpStatusCode.BadRequest, domainException.Code),
            _ => ((int)HttpStatusCode.InternalServerError, DEFAULT_TITLE),
        };

        httpContext.Response.StatusCode = statusCode;

        return await this.problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails =
            {
                Title = title,
                Detail = exception.Message,
            },
            Exception = exception,
        });
    }
}
