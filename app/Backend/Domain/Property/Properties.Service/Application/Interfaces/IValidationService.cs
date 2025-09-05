using FluentValidation.Results;
using Properties.Service.Application.Dtos;

namespace Properties.Service.Application.Interfaces
{
    public interface IValidationService
    {
        ValidationResult ValidateOwnerCreation(OwnerForCreationDto dto);
        ValidationResult ValidateOwnerUpdate(OwnerForUpdateDto dto);
    }
}
