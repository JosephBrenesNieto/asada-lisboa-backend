using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using AsadaLisboaBackend.Services.Exceptions;

namespace AsadaLisboaBackend.ErrorHandling
{
    public class ExistingValueErrorHandling : IExceptionHandler
    {
        private readonly ILogger<ExistingValueErrorHandling> _logger;
        private readonly IProblemDetailsService _problemDetailsService;

        public ExistingValueErrorHandling(IProblemDetailsService problemDetailsService, ILogger<ExistingValueErrorHandling> logger)
        {
            _logger = logger;
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ExistingValueException existingValueException)
                return false;

            _logger.LogError(exception, "Error Global - Error al utilizar un valor ya existente.");

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails()
                {
                    Detail = exception.Message,
                    Title = "Nombre del valor utilizado",
                    Status = StatusCodes.Status400BadRequest,
                }
            });

            return true;
        }
    }
}
