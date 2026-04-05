using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace AsadaLisboaBackend.ErrorHandling
{
    internal sealed class ArgumentErrorHandling : IExceptionHandler
    {
        private readonly ILogger<ArgumentErrorHandling> _logger;
        private readonly IProblemDetailsService _problemDetailsService;

        public ArgumentErrorHandling(IProblemDetailsService problemDetailsService, ILogger<ArgumentErrorHandling> logger)
        {
            _logger = logger;
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ArgumentException argumentException)
                return false;

            _logger.LogError(exception, "Error Global - Error en el valor enviado.");

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails()
                {
                    Detail = exception.Message,
                    Title = "Error en el valor enviado",
                    Status = StatusCodes.Status400BadRequest,
                }
            });

            return true;
        }
    }
}
