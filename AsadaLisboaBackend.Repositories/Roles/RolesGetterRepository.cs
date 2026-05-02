using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Models.DTOs.Role;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.RepositoryContracts.Roles;

namespace AsadaLisboaBackend.Repositories.Roles
{
    public class RolesGetterRepository : IRolesGetterRepository
    {
        private readonly ApplicationDbContext _context;

        public RolesGetterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoleResponseDTO>> GetRoles()
        {
            return await _context.Roles
                .Select(RoleExtensions.MapRoleResponseDTO())
                .ToListAsync();
        }
    }
}
