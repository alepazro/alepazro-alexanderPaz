using Properties.Service.Domain.Entities;

namespace Properties.Service.Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Task AddAuthorAsync(Property property);
        Task<bool> PropertyExists(Guid propertyId);
        Task DeletePropertyAsync(Property property);
        Task<Property> GetPropertyAsync(Guid propertyId);
        Task<List<Property>> GetPropertyPropertyAsync();
        Task<IEnumerable<Property>> GetPropertysAsync(List<Guid> propertyIds);
        Task UpdatePropertyAsync(Property property);
    }
}
