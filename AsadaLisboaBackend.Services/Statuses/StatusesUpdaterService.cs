using AsadaLisboaBackend.Models.Enums;
using AsadaLisboaBackend.ServiceContracts.Statuses;
using AsadaLisboaBackend.RepositoryContracts.Statuses;
using Microsoft.Extensions.Logging;

namespace AsadaLisboaBackend.Services.Statuses
{
    public class StatusesUpdaterService : IStatusesUpdaterService
    {
        private readonly IStatusesGetterRepository _statusesGetterRepository;
        private readonly IStatusesUpdaterRepository _statusesUpdaterRepository;
        private readonly ILogger<StatusesUpdaterService> _logger;

        public StatusesUpdaterService(IStatusesGetterRepository statusesGetterRepository, IStatusesUpdaterRepository statusesUpdaterRepository, ILogger<StatusesUpdaterService> logger)
        {
            _statusesGetterRepository = statusesGetterRepository;
            _statusesUpdaterRepository = statusesUpdaterRepository;
            _logger = logger;
        }

        public async Task ChangeStatus(Guid objectId, Guid statusId, ObjectTypeEnum objectType)
        {
            try
            {

                var status = await _statusesGetterRepository.GetStatus(statusId);

                if (status == null)
                {
                    _logger.LogWarning(
                        "No se encontró el estado con StatusId: {StatusId} para ObjectId: {ObjectId}",
                        statusId,
                        objectId
                    );
                    throw new InvalidOperationException("El estado no existe");
                }

                await _statusesUpdaterRepository.ChangeStatus(objectId, status.Id, objectType);

                _logger.LogInformation(
                    "Cambio de estado exitoso. ObjectId: {ObjectId}, NuevoStatusId: {StatusId}, Tipo: {ObjectType}",
                    objectId,
                    status.Id,
                    objectType
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error al cambiar el estado. ObjectId: {ObjectId}, StatusId: {StatusId}, Tipo: {ObjectType}",
                    objectId,
                    statusId,
                    objectType
                );
                throw;
            }


        }
        }
    }
}
