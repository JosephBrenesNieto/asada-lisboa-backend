using AsadaLisboaBackend.Models.DTOs.Charge;
using AsadaLisboaBackend.ServiceContracts.Charges;
using AsadaLisboaBackend.RepositoryContracts.Charges;
using Microsoft.Extensions.Logging;
using AsadaLisboaBackend.Services.Exceptions;

namespace AsadaLisboaBackend.Services.Charges
{
    public class ChargesGetterService : IChargesGetterService
    {
        private readonly IChargesGetterRepository _chargesGetterRepository;
        private readonly ILogger<ChargesUpdaterService> _logger;

        public ChargesGetterService(IChargesGetterRepository chargesGetterRepository, ILogger<ChargesUpdaterService> logger)
        {
            _chargesGetterRepository = chargesGetterRepository;
            _logger = logger;
        }

        public async Task<List<ChargeResponseDTO>> GetCharges()
        {
            try
            {
                return await _chargesGetterRepository.GetCharges();

            } catch (Exception ex) 
            {
                _logger.LogError(ex, "Ocurrió un error al intentar obtener la lista de cargos.");
                throw new CreateObjectException("Error al obtener la lista de cargos.");
            }
        }

        public async Task<bool> ExistsCharge(string name)
        {
            name = name.Trim().ToLower();
            return await _chargesGetterRepository.ExistsCharge(name);
        }
    }
}
