using Properties.Service.Application.Dtos;
using Properties.Service.Domain.Entities;

namespace Properties.Service.Domain.Interfaces
{
    public interface IOwnerRepository
    {
        Task AddOwnerAsync(Owner owner);
        Task<bool> OwnerExists(Guid ownerId);
        Task DeleteOwnerAsync(Owner owner);
        Task<Owner> GetOwnerAsync(Guid ownerId);
        Task<List<Owner>> GetOwnersAsync(OwnersResourceParameters ownersResourceParameters);
        Task<IEnumerable<Owner>> GetOwnersAsync(List<Guid> ownerIds);
        Task UpdateOwnerAsync(Owner owner);
    }
}
