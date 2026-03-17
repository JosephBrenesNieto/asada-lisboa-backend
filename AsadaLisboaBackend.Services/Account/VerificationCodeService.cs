using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Account;
using AsadaLisboaBackend.Services.Email;
using Microsoft.AspNetCore.Identity;
using AsadaLisboaBackend.Models.DTOs.Account;

namespace AsadaLisboaBackend.Services.Account
{
    public class VerificationCodeService : IVerificationCodeService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly VerificationCodeSendService _verificationCodeSendService;

        public VerificationCodeService(UserManager<ApplicationUser> userManager, VerificationCodeSendService verificationCodeSendService)
        {
            _userManager = userManager;
            _verificationCodeSendService = verificationCodeSendService;
        }

        public async Task<bool> GenerateCode(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) return false;


            var random = new Random();
            var code = random.Next(100000, 999999).ToString();

            //Send email with code 
            return await _verificationCodeSendService.SendVerificationCode(user.FirstName, email, code);
        }
    }
}
