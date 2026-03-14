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

        public RegisterUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IdentityResult> RegisterUser(RegisterRequestDTO dto)
        {
            //Verify if eamil exists
            var existinguser = await _userManager.FindByEmailAsync(dto.Email);

            if (existinguser != null)
                return BadRequest("El correo electrónico ya esta registrado ");

            //Register new user

            var user = new ApplicationUser
            {

                UserName = dto.UserName,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            return result;
        }
    }
}
