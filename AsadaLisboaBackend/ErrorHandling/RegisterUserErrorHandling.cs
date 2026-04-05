using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using AsadaLisboaBackend.Services.Exceptions;

namespace AsadaLisboaBackend.ErrorHandling
{
    internal sealed class RegisterUserErrorHandling : IExceptionHandler
    {
        private readonly ILogger<RegisterUserErrorHandling> _logger;
        private readonly IProblemDetailsService _problemDetailsService;

        public RegisterUserErrorHandling(IProblemDetailsService problemDetailsService, ILogger<RegisterUserErrorHandling> logger)
        {
            _logger = logger;
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not RegisterUserException registerUserException)
                return false;

            _logger.LogError(exception, "Error Global - Error al registrar un usuario.");

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails()
                {
                    Detail = exception.Message,
                    Title = "Error al registar usuario",
                    Status = StatusCodes.Status401Unauthorized,
                }
            });

            return true;
        }
    }
}
