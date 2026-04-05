using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Users;

namespace AsadaLisboaBackend.Services.Users
{
    public class UsersDeleterService : IUsersDeleterService
    {
        private readonly ILogger<UsersDeleterService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersDeleterService(UserManager<ApplicationUser> userManager, ILogger<UsersDeleterService> logger)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user is null)
            {
                _logger.LogWarning("Usuario con id {UserId} no encontrado para eliminación.", id);
                throw new NotFoundException("Usuario inexistente.");
            }

            await _userManager.DeleteAsync(user);
            _logger.LogInformation("Usuario con id {UserId} eliminado exitosamente.", id);
        }
    }
}
