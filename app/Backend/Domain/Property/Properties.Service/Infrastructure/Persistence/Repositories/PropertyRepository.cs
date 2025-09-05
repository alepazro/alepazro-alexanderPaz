using Properties.Service.Domain.Entities;
using Properties.Service.Domain.Interfaces;
using Properties.Service.Infrastructure.Persistence.Contexts;

namespace Properties.Service.Infrastructure.Persistence.Repositories
{
    public class PropertyRepository: IPropertyRepository
    {
        private readonly PropertiesContext _context;
        public PropertyRepository(
            PropertiesContext context
        )
        {
            _context = context;
        }

        public Task AddAuthorAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task DeletePropertyAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public Task<Property> GetPropertyAsync(Guid propertyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Property>> GetPropertyPropertyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetPropertysAsync(List<Guid> propertyIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PropertyExists(Guid propertyId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePropertyAsync(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
