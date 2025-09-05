using System.ComponentModel.DataAnnotations;
using Properties.Service.Application.Dtos;

namespace Properties.Service.Infrastructure.Http.Results.Owners
{   
    public class UpdateOwnerResult
    {
        public OwnerDto OwnerUpserted { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; } = new();
        public bool Success { get; set; }
    }
}
