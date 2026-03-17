using AsadaLisboaBackend.Models.DTOs.Account;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsadaLisboaBackend.Services.Account
{
    public class RegisterUserService : IRegisterUserService
    {

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IVerificationCodeService _iVerificationCodeService;

        public RegisterUserService(UserManager<ApplicationUser> userManager, IVerificationCodeService iVerificationCodeService)
        {
            _userManager = userManager;
            _iVerificationCodeService = iVerificationCodeService;
        }


        public async Task<IdentityResult> RegisterUser(RegisterRequestDTO registerRequestDTO)
        {
            //Verify if email exists
            var existinguser = await _userManager.FindByEmailAsync(registerRequestDTO.Email);

            if (existinguser != null)
                return BadRequest("El correo electrónico ya esta registrado ");

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
