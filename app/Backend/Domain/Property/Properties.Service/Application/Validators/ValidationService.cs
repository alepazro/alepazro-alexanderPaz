using FluentValidation;
using FluentValidation.Results;
using Properties.Service.Application.Dtos;
using Properties.Service.Application.Interfaces;

namespace Properties.Service.Application.Validators
{
    public class ValidationService : IValidationService
    {
        private readonly IValidator<OwnerForCreationDto> _ownerCreationValidator;
        private readonly IValidator<OwnerForUpdateDto> _ownerUpdateValidator;

        public ValidationService(
            IValidator<OwnerForCreationDto> authorCreationValidator,
            IValidator<OwnerForUpdateDto> authorUpdateValidator
        )
        {
            _ownerCreationValidator = authorCreationValidator;
            _ownerUpdateValidator = authorUpdateValidator;
        }
        public ValidationResult ValidateOwnerCreation(OwnerForCreationDto dto)
        {
            return _ownerCreationValidator.Validate(dto);
        }        
        public ValidationResult ValidateOwnerUpdate(OwnerForUpdateDto dto)
        {
            return _ownerUpdateValidator.Validate(dto);
        }

    }

}
