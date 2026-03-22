using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.DTOs.AboutUs;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.RepositoryContracts.AboutUsSections;

namespace AsadaLisboaBackend.Repositories.AboutUsSections
{
    public class AboutUsSectionsUpdaterRepository : IAboutUsSectionsUpdaterRepository
    {
        private readonly ApplicationDbContext _context;

        public AboutUsSectionsUpdaterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AboutUsSection> UpdateAboutUsSection(Guid id, AboutUsRequestDTO aboutUsRequestDTO)
        {
            var affectedRows = await _context.AboutUsSections
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(p => p
                    .SetProperty(c => c.SectionType, aboutUsRequestDTO.SectionType)
                    .SetProperty(c => c.Content, aboutUsRequestDTO.Content)
                    .SetProperty(c => c.Order, aboutUsRequestDTO.Order));

            if (affectedRows < 1)
                throw new NotFoundException("Error al modificar la sección.");

            return new AboutUsSection()
            {
                Id = id,
                Order = aboutUsRequestDTO.Order,
                Content = aboutUsRequestDTO.Content,
                SectionType = aboutUsRequestDTO.SectionType,
            };
        }
    }
}
