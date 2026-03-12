using Microsoft.AspNetCore.Identity;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Users;

namespace AsadaLisboaBackend.Services.Users
{
    public class UsersDeleterService : IUsersDeleterService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersDeleterService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user is null)
                throw new ArgumentNullException("Usuario inexistente.");

            await _userManager.DeleteAsync(user);
        }
    }
}
