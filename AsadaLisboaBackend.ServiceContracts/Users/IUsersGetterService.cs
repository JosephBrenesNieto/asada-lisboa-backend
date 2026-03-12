using AsadaLisboaBackend.Models.DTOs.Users;
using AsadaLisboaBackend.Models.DTOs.Shared;

namespace AsadaLisboaBackend.ServiceContracts.Users
{
    public interface IUsersGetterService
    {
        public Task<PageResponseDTO<UserResponseDTO>> GetUsers(SearchSortRequestDTO searchSortRequestDTO);
        public Task<UserDetailResponseDTO?> GetUser(Guid id);
    }
}
