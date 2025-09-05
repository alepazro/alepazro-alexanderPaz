using Microsoft.AspNetCore.Authorization;
using Properties.Service.Infrastructure.Http.EndpointHandlers;

namespace Properties.Service.Infrastructure.Http.HttpExtensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterOwnersEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var OwnersEndpoints = endpointRouteBuilder
                .MapGroup("api/Owners")
                .WithTags("Owners");

            OwnersEndpoints.MapGet("", OwnersHandlers.GetOwnersAsync)
                .WithName("GetOwners")
                .WithOpenApi()
                .RequireAuthorization(new AuthorizeAttribute { Roles = "realm-role" }); 

            OwnersEndpoints.MapGet("/{OwnerId:guid}", OwnersHandlers.GetOwnerByOwnerIdAsync)
                .WithName("GetOwner")
                .WithOpenApi(); 

            OwnersEndpoints.MapPost("", OwnersHandlers.CreateOwnerAsync)
               .WithName("CreateOwner")
               .WithOpenApi();           

            OwnersEndpoints.MapDelete("/{OwnerId:guid}", OwnersHandlers.DeleteOwnerAsync)
                .WithName("DeleteOwner")
                .WithOpenApi().RequireAuthorization(new AuthorizeAttribute { Roles = "realm-role" }); 

            OwnersEndpoints.MapPut("/{OwnerId:guid}", OwnersHandlers.UpdateOwnerAsync)
                .WithName("UpdateOwner")
                .WithOpenApi().RequireAuthorization(new AuthorizeAttribute { Roles = "realm-role" }); 
        }
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterOwnersEndpoints();
        }
    }

}
