using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using AsadaLisboaBackend.Services.Exceptions;

namespace AsadaLisboaBackend.ErrorHandling
{
    internal sealed class InvalidCredentialsErrorHandling : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService;
        private readonly ILogger<InvalidCredentialsErrorHandling> _logger;

        public InvalidCredentialsErrorHandling(IProblemDetailsService problemDetailsService, ILogger<InvalidCredentialsErrorHandling> logger)
        {
            _logger = logger;
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not InvalidCredentialsException invalidCredentialsException) 
                return false;

            _logger.LogError(exception, "Error Global - Error en credenciales de acceso de un usuario.");

            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

            await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails()
                {
                    Detail = exception.Message,
                    Title = "Error en credenciales de usuario",
                    Status = StatusCodes.Status401Unauthorized,
                }
            });

            return true;
        }
    }
}
