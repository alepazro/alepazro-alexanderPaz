using Properties.Service.Application.Dtos;
using Properties.Service.Infrastructure.Http.Results.Owners;

namespace Properties.Service.Application.Interfaces
{   
    public interface IPropertyApplicationService
    {
        Task<GetOwnersResult> GetOwnersAsync(OwnersResourceParameters ownersResourceParameters);
        Task<bool> OwnerExistsAsync(Guid ownerId);
        Task<CreateOwnerResult> CreateOwnerAsync(OwnerForCreationDto owner);
        Task<bool?> DeleteOwnerAsync(Guid ownerId);
        Task<GetOwnerByOwnerIdResult> GetOwnerByOwnerIdAsync(Guid ownerId);
        Task<UpdateOwnerResult> UpdateOwnerAsync(Guid OwnerId, OwnerForUpdateDto owner);
    }
}
