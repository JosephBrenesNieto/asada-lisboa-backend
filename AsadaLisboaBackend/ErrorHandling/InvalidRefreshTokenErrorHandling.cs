using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using AsadaLisboaBackend.Services.Exceptions;

namespace AsadaLisboaBackend.ErrorHandling
{
    internal sealed class InvalidRefreshTokenErrorHandling : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService;
        private readonly ILogger<InvalidRefreshTokenErrorHandling> _logger;

        public InvalidRefreshTokenErrorHandling(IProblemDetailsService problemDetailsService, ILogger<InvalidRefreshTokenErrorHandling> logger)
        {
            _logger = logger;
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not InvalidRefreshTokenException invalidRefreshTokenException) 
                return false;

            _logger.LogError(exception, "Error Global - Error al refrescar un token.");

            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

            await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails()
                {
                    Detail = exception.Message,
                    Title = "Error en refrescamiento de token",
                    Status = StatusCodes.Status401Unauthorized,
                }
            });

            return true;
        }
    }
}
