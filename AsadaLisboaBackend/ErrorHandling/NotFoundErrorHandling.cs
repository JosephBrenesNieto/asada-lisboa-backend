using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using AsadaLisboaBackend.Services.Exceptions;

namespace AsadaLisboaBackend.ErrorHandling
{
    internal sealed class NotFoundErrorHandling : IExceptionHandler
    {
        private readonly ILogger<NotFoundErrorHandling> _logger;
        private readonly IProblemDetailsService _problemDetailsService;

        public NotFoundErrorHandling(IProblemDetailsService problemDetailsService, ILogger<NotFoundErrorHandling> logger)
        {
            _logger = logger;
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NotFoundException notFoundException) 
                return false;

            _logger.LogError(exception, "Error Global - Elemento buscado no encontrado.");

            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

            await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails()
                {
                    Detail = exception.Message,
                    Title = "Error en búsqueda",
                    Status = StatusCodes.Status404NotFound,
                }
            });

            return true;
        }
    }
}
