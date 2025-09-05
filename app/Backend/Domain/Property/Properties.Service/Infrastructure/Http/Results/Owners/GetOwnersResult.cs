using Properties.Service.Application.Dtos;

namespace Properties.Service.Infrastructure.Http.Results.Owners
{
    public class GetOwnersResult
    {
        public List<OwnerDto> Owners { get; set; }
    }
}
