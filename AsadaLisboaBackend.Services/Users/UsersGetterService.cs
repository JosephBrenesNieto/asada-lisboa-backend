using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.User;
using AsadaLisboaBackend.RepositoryContracts.Users;
using AsadaLisboaBackend.ServiceContracts.Users;
using AsadaLisboaBackend.Services.Exceptions;
using Microsoft.Extensions.Logging;

namespace AsadaLisboaBackend.Services.Users
{
    public class UsersGetterService : IUsersGetterService
    {
        private readonly ILogger<UsersGetterService> _logger;
        private readonly IUsersGetterRepository _usersGetterRepository;

        public UsersGetterService(IUsersGetterRepository usersGetterRepository, ILogger<UsersGetterService> logger)
        {
            _logger = logger;
            _usersGetterRepository = usersGetterRepository;
        }

        public async Task<PageResponseDTO<UserResponseDTO>> GetUsers(SearchSortRequestDTO searchSortRequestDTO)
        {
            searchSortRequestDTO.Offset = (Math.Max(searchSortRequestDTO.Page, 1) - 1) * searchSortRequestDTO.Take;

            return await _usersGetterRepository.GetUsers(searchSortRequestDTO);
        }

        public async Task<UserDetailResponseDTO?> GetUser(Guid id)
        {
            var user = await _usersGetterRepository.GetUser(id);

            if (user is null)
            {
                _logger.LogWarning("Usuario con id {UserId} no encontrado.", id);
                throw new NotFoundException("Usuario inexistente.");
            }

            return user;
        }
    }
}
