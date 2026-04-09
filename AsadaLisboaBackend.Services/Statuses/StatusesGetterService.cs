using AsadaLisboaBackend.Models.DTOs.Status;
using AsadaLisboaBackend.ServiceContracts.Statuses;
using AsadaLisboaBackend.RepositoryContracts.Statuses;
using Microsoft.Extensions.Logging;

namespace AsadaLisboaBackend.Services.Statuses
{
    public class StatusesGetterService : IStatusesGetterService
    {
        private readonly IStatusesGetterRepository _statusesGetterRepository;
        private readonly ILogger<StatusesGetterService> _logger;

        public StatusesGetterService(IStatusesGetterRepository statusesGetterRepository, ILogger<StatusesGetterService> logger)
        {
            _statusesGetterRepository = statusesGetterRepository;
            _logger = logger;
        }

        public async Task<List<StatusResponseDTO>> GetStatuses()
        {
            try
            {
                var result = await _statusesGetterRepository.GetStatuses();

                _logger.LogInformation("Obtención exitosa de estados.");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los estados");
                throw;
            }
        }
    }
}
