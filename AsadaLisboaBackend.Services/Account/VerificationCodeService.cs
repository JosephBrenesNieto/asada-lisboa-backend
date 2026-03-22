using AsadaLisboaBackend.Models.DTOs.Account;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Account;
using AsadaLisboaBackend.Services.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var generateToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(generateToken));


            //Send email with code 
            return await _verificationCodeSendService.SendVerificationCode(user.FirstName, email, encodedToken);
        }

        public async Task<bool> ConfirmEmailAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) return false;

            // Decodificar token
            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            return result.Succeeded;

        }
    }
}
