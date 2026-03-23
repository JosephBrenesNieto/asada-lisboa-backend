using AsadaLisboaBackend.Models.DTOs.Account;

namespace AsadaLisboaBackend.ServiceContracts.Account
{
    public  interface IRegisterUserService
    {
        public Task RegisterUser(RegisterRequestDTO registerRequestDTO);
    }
}
