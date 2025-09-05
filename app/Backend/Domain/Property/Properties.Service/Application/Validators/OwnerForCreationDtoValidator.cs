using FluentValidation;
using Properties.Service.Application.Dtos;

namespace Properties.Service.Application.Validators
{   
    public class OwnerForCreationDtoValidator : AbstractValidator<OwnerForCreationDto>
    {
        public OwnerForCreationDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
