using System.Text.Json.Serialization;

namespace Properties.Service.Infrastructure.Security.Extensions
{
    public class AccessRoles
    {
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }
    }
}
