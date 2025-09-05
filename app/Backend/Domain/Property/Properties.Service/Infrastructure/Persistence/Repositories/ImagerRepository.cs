using Properties.Service.Domain.Entities;
using Properties.Service.Domain.Interfaces;
using Properties.Service.Infrastructure.Persistence.Contexts;

namespace Properties.Service.Infrastructure.Persistence.Repositories
{
    public class ImagerRepository :IImagerRepository
    {
        private readonly PropertiesContext _context;
        public ImagerRepository(
            PropertiesContext context
        )
        {
            _context = context;
        }

        public Task AddImageForPropertyAsync(Guid propertyId, Image image)
        {
            throw new NotImplementedException();
        }

        public Task DeleteImageAsync(Image image)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImageForPropertyAsync(Guid propertyId, Guid imageId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Image>> GetImagesForPropertyAsync(Guid propertyId)
        {
            throw new NotImplementedException();
        }

        public Task<Image> UpdateImageAsync(Image image)
        {
            throw new NotImplementedException();
        }

        public Task UpdateImageForPropertyAsync(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
