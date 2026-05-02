using System.Linq.Expressions;
using AsadaLisboaBackend.Models.IdentityModels;

namespace AsadaLisboaBackend.Models.DTOs.Role
{
    public class RoleResponseDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
    }

    public static partial class RoleExtensions
    {
        public static Expression<Func<ApplicationRole, RoleResponseDTO>> MapRoleResponseDTO()
        {
            return role => new RoleResponseDTO
            {
                Id = role.Id,
                Name = role.Name,
            };
        }
    }
}
