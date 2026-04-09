using Microsoft.Extensions.Logging;
using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Models.DTOs.Charge;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.ServiceContracts.Charges;
using AsadaLisboaBackend.RepositoryContracts.Charges;

namespace AsadaLisboaBackend.Services.Charges
{
    public class ChargesAdderService : IChargesAdderService
    {
        private readonly IChargesGetterService _chargesGetterService;
        private readonly IChargesAdderRepository _chargesAdderRepository;
        private readonly ILogger<ChargesAdderService> _logger;

        public ChargesAdderService(IChargesGetterService chargesGetterService, IChargesAdderRepository chargesAdderRepository, ILogger<ChargesAdderService> logger)
        {
            _chargesGetterService = chargesGetterService;
            _chargesAdderRepository = chargesAdderRepository;
            _logger = logger;
        }

        public async Task<ChargeResponseDTO> CreateCharge(string nameCharge)
        {

            try 
            {
                var existsCharge = await _chargesGetterService.ExistsCharge(nameCharge);

                if (existsCharge){

                    _logger.LogWarning("No se pudo crear el cargo '{ChargeName}' porque ya existe.", nameCharge);
                    throw new ExistingValueException("El nombre del cargo ya existe.");
                }
                var charge = new Charge { Name = nameCharge };

               
                var result = await _chargesAdderRepository.CreateCharge(charge);

                return result;

            } catch (Exception ex) {
                _logger.LogError(ex, "Error al crear el cargo '{ChargeName}'", nameCharge);
                throw new CreateObjectException("Error al crear el cargo.");
            }
        }
    }
}
