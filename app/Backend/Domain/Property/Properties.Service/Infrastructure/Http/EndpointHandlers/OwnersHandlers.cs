using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Properties.Service.Application.Dtos;
using Properties.Service.Application.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Properties.Service.Infrastructure.Http.EndpointHandlers
{    
    public static class OwnersHandlers
    {
        public static async Task<Results<BadRequest, Ok<List<OwnerDto>>>> GetOwnersAsync(
            [FromServices] IPropertyApplicationService _PropertyApplicationService,
            [AsParameters] OwnersResourceParameters ownersResourceParameters
        )
        {
            var result = await _PropertyApplicationService.GetOwnersAsync(ownersResourceParameters);
            return TypedResults.Ok(result.Owners);
        }
        public static async Task<Results<BadRequest, NotFound, Ok<OwnerDto>>> GetOwnerByOwnerIdAsync(
           [FromServices] IPropertyApplicationService _PropertyApplicationService,
           Guid OwnerId
        )
        {
            var result = await _PropertyApplicationService.GetOwnerByOwnerIdAsync(OwnerId);
            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(result.Owner);
        }

        public static async Task<Results<BadRequest, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<OwnerDto>, Ok<OwnerDto>>> CreateOwnerAsync(
            [FromServices] IPropertyApplicationService _PropertyApplicationService,
            [FromBody] OwnerForCreationDto Owner
        )
        {
            if (Owner == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _PropertyApplicationService.CreateOwnerAsync(Owner);
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            return TypedResults.CreatedAtRoute(result.Owner, $"GetOwner", new { result.Owner.OwnerId });
        }
        
        public static async Task<Results<NotFound, NoContent>> DeleteOwnerAsync(
           [FromServices] IPropertyApplicationService _PropertyApplicationService,
           Guid ownerId
        )
        {
            var result = await _PropertyApplicationService.DeleteOwnerAsync(ownerId);

            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.NoContent();
        }

        public static async Task<Results<BadRequest, NotFound, NoContent, CreatedAtRoute<OwnerDto>, UnprocessableEntity<List<ValidationResult>>, Ok<OwnerDto>>> UpdateOwnerAsync(
           [FromServices] IPropertyApplicationService _PropertyApplicationService,
           [FromBody] OwnerForUpdateDto Owner,
           Guid ownerId
        )
        {
            if (Owner == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _PropertyApplicationService.UpdateOwnerAsync(ownerId, Owner);
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            if (result.Success && result.OwnerUpserted != null)
            {
                return TypedResults.CreatedAtRoute(result.OwnerUpserted, $"GetOwner", new { ownerId = result.OwnerUpserted.OwnerId });
            }

            return TypedResults.NoContent();
        }
    }

}
