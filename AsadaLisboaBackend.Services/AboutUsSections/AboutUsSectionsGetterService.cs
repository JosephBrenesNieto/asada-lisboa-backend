using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.AboutUs;
using AsadaLisboaBackend.ServiceContracts.AboutUsSections;
using AsadaLisboaBackend.RepositoryContracts.AboutUsSections;
using Microsoft.Extensions.Logging;

namespace AsadaLisboaBackend.Services.AboutUsSections
{
    public class AboutUsSectionsGetterService : IAboutUsSectionsGetterService
    {
        private readonly IAboutUsSectionsGetterRepository _aboutUsSectionsGetterRepository;
        private readonly ILogger<AboutUsSectionsGetterService> _logger;

        public AboutUsSectionsGetterService(IAboutUsSectionsGetterRepository aboutUsSectionsGetterRepository, ILogger<AboutUsSectionsGetterService> logger)
        {
            _aboutUsSectionsGetterRepository = aboutUsSectionsGetterRepository;
            _logger = logger;
        }

        public async Task<PageResponseDTO<AboutUsResponseDTO>> GetAboutUsSections(SearchSortRequestDTO searchSortRequestDTO)
        {
            try
            {
                searchSortRequestDTO.Offset = (Math.Max(searchSortRequestDTO.Page, 1) - 1) * searchSortRequestDTO.Take;

               var result = await _aboutUsSectionsGetterRepository.GetAboutUsSections(searchSortRequestDTO);

                _logger.LogInformation(
                    "Obtención exitosa de AboutUsSections. Página: {Page}, Tamaño: {Take}",
                    searchSortRequestDTO.Page,
                    searchSortRequestDTO.Take
                );

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error al obtener AboutUsSections. Página: {Page}, Tamaño: {Take}",
                    searchSortRequestDTO.Page,
                    searchSortRequestDTO.Take
                );
                throw;
            }
        }
    }
}
