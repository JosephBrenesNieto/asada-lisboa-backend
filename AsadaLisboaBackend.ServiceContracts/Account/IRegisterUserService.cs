using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AsadaLisboaBackend.Models.DTOs.Account;

namespace AsadaLisboaBackend.ServiceContracts.Account
{
    public  interface IRegisterUserService
    {
        public Task<IdentityResult> RegisterUser(RegisterRequestDTO registerRequestDTO);
    }
}
