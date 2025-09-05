using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Properties.Service.Application.Interfaces;
using Properties.Service.Application.Mappers;
using Properties.Service.Application.Services;
using Properties.Service.Application.Validators;

namespace Properties.Service.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(OwnerMapper));
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<OwnerForCreationDtoValidator>());
            services.AddTransient<IValidationService, ValidationService>();
            services.AddScoped<IPropertyApplicationService, PropertyApplicationService>();
        }
    }
}
