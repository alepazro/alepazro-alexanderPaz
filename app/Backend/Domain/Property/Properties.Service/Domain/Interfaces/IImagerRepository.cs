using Properties.Service.Domain.Entities;

namespace Properties.Service.Domain.Interfaces
{
    public interface IImagerRepository
    {
        Task AddImageForPropertyAsync(Guid propertyId, Image image);
        Task DeleteImageAsync(Image image);
        Task<Image> GetImageForPropertyAsync(Guid propertyId, Guid imageId);
        Task<IEnumerable<Image>> GetImagesForPropertyAsync(Guid propertyId);
        Task<Image> UpdateImageAsync(Image image);
        Task UpdateImageForPropertyAsync(Image image);
    }
}
