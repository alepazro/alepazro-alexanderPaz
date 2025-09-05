using FluentValidation;
using Properties.Service.Application.Dtos;

namespace Properties.Service.Application.Validators
{   
    public class OwenerForUpdateDtoValidator : AbstractValidator<OwnerForUpdateDto>
    {
        public OwenerForUpdateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
