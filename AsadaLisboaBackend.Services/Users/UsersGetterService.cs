using AsadaLisboaBackend.Utils;
using AsadaLisboaBackend.Models.DTOs.Users;
using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.ServiceContracts.Users;
using AsadaLisboaBackend.RepositoryContracts.Users;

namespace AsadaLisboaBackend.Services.Users
{
    public class UsersGetterService : IUsersGetterService
    {
        private readonly IUsersGetterRepository _usersGetterRepository;

        public UsersGetterService(IUsersGetterRepository usersGetterRepository)
        {
            _usersGetterRepository = usersGetterRepository;
        }

        public async Task<PageResponseDTO<UserResponseDTO>> GetUsers(SearchSortRequestDTO searchSortRequestDTO)
        {
            searchSortRequestDTO.Offset = (Math.Max(searchSortRequestDTO.Page, 1) - 1) * searchSortRequestDTO.Take;

            return await _usersGetterRepository.GetUsers(searchSortRequestDTO);
        }

        public async Task<UserDetailResponseDTO?> GetUser(Guid id)
        {
            return await _usersGetterRepository.GetUser(id);
        }
    }
}
