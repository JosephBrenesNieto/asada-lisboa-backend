using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using AsadaLisboaBackend.Utils;
using AsadaLisboaBackend.Models.DTOs.User;
using AsadaLisboaBackend.Models.DTOs.Error;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Users;
using AsadaLisboaBackend.RepositoryContracts.Charges;
using AsadaLisboaBackend.ServiceContracts.MemoryCaches;

namespace AsadaLisboaBackend.Services.Users
{
    public class UsersUpdaterService : IUsersUpdaterService
    {
        private readonly ILogger<UsersUpdaterService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMemoryCachesService _memoryCachesService;
        private readonly IChargesGetterRepository _chargesGetterRepository;

        public UsersUpdaterService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IChargesGetterRepository chargesGetterRepository, ILogger<UsersUpdaterService> logger, IMemoryCachesService memoryCachesService)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _memoryCachesService = memoryCachesService;
            _chargesGetterRepository = chargesGetterRepository;
        }

        public async Task UpdateUser(Guid id, UserUpdateRequestDTO userUpdateRequestDTO)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user is null)
            {
                _logger.LogError("Intento de actualización de usuario con id {UserId} no encontrado.", id);
                throw new NotFoundException("Usuario inexistente.");
            }

            var charge = await _chargesGetterRepository.GetCharge(userUpdateRequestDTO.ChargeId);

            if (charge is null)
            {
                _logger.LogError("Cargo seleccionado con id {ChargeId} no encontrado para el usuario {UserId}.", userUpdateRequestDTO.ChargeId, id);
                throw new NotFoundException("Cargo seleccionado no encontrado.");
            }

            var role = await _roleManager.FindByIdAsync(userUpdateRequestDTO.RoleId.ToString());

            if (role is null)
            {
                _logger.LogError("Rol seleccionado con id {RoleId} no encontrado para el usuario {UserId}.", userUpdateRequestDTO.RoleId, id);
                throw new NotFoundException("Rol seleccionado no encontrado.");
            }

            user.ChargeId = charge.Id;
            user.FirstName = userUpdateRequestDTO.FirstName;
            user.PhoneNumber = userUpdateRequestDTO.PhoneNumber;
            user.FirstLastName = userUpdateRequestDTO.FirstLastName;
            user.SecondLastName = userUpdateRequestDTO.SecondLastName;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                _logger.LogError("Error al actualizar usuario con id {UserId}. Errores: {Errors}", id, string.Join(", ", result.Errors.Select(e => $"{e.Code}: {e.Description}")));
                throw new IdentityErrorException(
                    "Error al actualizar usuario.", 
                    result.Errors.Select(e => new ErrorDetailResponseDTO(e.Code, e.Description)
                    ).ToList()
                );
            }

            var currentRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            if(!string.IsNullOrEmpty(currentRole) && !string.IsNullOrWhiteSpace(currentRole))
            {
                if (!role.Name!.Equals(currentRole, StringComparison.InvariantCultureIgnoreCase))
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
            }

            await _userManager.AddToRoleAsync(user, role.Name!);

            _memoryCachesService.RemoveById(Constants.CACHE_USERS, user.Id);
            _memoryCachesService.ChangeVersion(Constants.CACHE_USERS);
        }
    }
}
