using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.Models.DTOs.Configuration;
using AsadaLisboaBackend.RepositoryContracts.Configurations;

namespace AsadaLisboaBackend.Repositories.Configurations
{
    public class ConfigurationsUpdaterRepository : IConfigurationsUpdaterRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationsUpdaterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VisualSetting> UpdateConfiguration(Guid id, ConfigurationsRequestDTO configurationRequestDTO)
        {
            var affectedRows = await _context.VisualSettings
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(p => p
                    .SetProperty(c => c.SettingType, configurationRequestDTO.SettingType)
                    .SetProperty(c => c.Value, configurationRequestDTO.Value)
                    .SetProperty(c => c.Order, configurationRequestDTO.Order));

            if (affectedRows < 1)
                throw new NotFoundException("Error al modificar la configuración.");

            return new VisualSetting()
            {
                Id = id,
                Order = configurationRequestDTO.Order,
                Value = configurationRequestDTO.Value,
                SettingType = configurationRequestDTO.SettingType,
            };
        }
    }
}
