using Microsoft.Extensions.Logging;
using AsadaLisboaBackend.Utils;
using AsadaLisboaBackend.Models.DTOs.Role;
using AsadaLisboaBackend.ServiceContracts.Roles;
using AsadaLisboaBackend.RepositoryContracts.Roles;
using AsadaLisboaBackend.ServiceContracts.MemoryCaches;

namespace AsadaLisboaBackend.Services.Roles
{
    public class RolesGetterService : IRolesGetterService
    {
        private readonly ILogger<RolesGetterService> _logger;
        private readonly IMemoryCachesService _memoryCachesService;
        private readonly IRolesGetterRepository _rolesGetterRepository;

        public RolesGetterService(IRolesGetterRepository rolesGetterRepository, ILogger<RolesGetterService> logger, IMemoryCachesService memoryCachesService)
        {
            _logger = logger;
            _memoryCachesService = memoryCachesService;
            _rolesGetterRepository = rolesGetterRepository;
        }

        public async Task<List<RoleResponseDTO>> GetRoles()
        {
            _logger.LogInformation("Los roles para usuarios han sido solicitados.");

            return await _memoryCachesService.GetOrCreateCacheList<List<RoleResponseDTO>>(
                resource: Constants.CACHE_ROLES,
                request: "",
                create: () => _rolesGetterRepository.GetRoles(),
                time: TimeSpan.FromMinutes(5));
        }
    }
}
