using Microsoft.AspNetCore.Builder;
using Properties.Service.Infrastructure.Http.HttpExtensions;
using Properties.Service.Infrastructure.Persistence.Extensions;
using Properties.Service.Infrastructure.Security.Extensions;

namespace Properties.Service.Infrastructure.Extensions
{
    public class InfrastructureOptions
    {
        public string ConnectionString { get; set; }
    }
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, Action<InfrastructureOptions> configure)
        {
            var options = new InfrastructureOptions();
            configure(options);


            services.AddHttp();
            services.AddPersistence(opt => opt.ConnectionString = options.ConnectionString);
            services.AddSecurity();

          
        }
    }
}
