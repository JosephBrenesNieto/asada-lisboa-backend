using Microsoft.AspNetCore.Identity;
using AsadaLisboaBackend.Models.DTOs.Account;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Account;

namespace AsadaLisboaBackend.Services.Account
{
    public class RegisterUserService : IRegisterUserService
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IdentityResult> RegisterUser(RegisterRequestDTO registerRequestDTO)
        {
            //Verify if email exists
            var existinguser = await _userManager.FindByEmailAsync(registerRequestDTO.Email);

            if (existinguser != null)
                throw new NotFoundException("El correo electrónico ya esta registrado ");

            //Register new user

            var user = new ApplicationUser
            {

                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerRequestDTO.Password);


            user.EmailConfirmed = true;
            user.IsActive = true;
            await _userManager.UpdateAsync(user);

            return result;
        }
    }
}
