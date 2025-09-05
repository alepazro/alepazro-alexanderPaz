using Microsoft.EntityFrameworkCore;
using Properties.Service.Domain.Interfaces;
using Properties.Service.Infrastructure.Persistence.Contexts;
using Properties.Service.Infrastructure.Persistence.Repositories;
using Properties.Service.Infrastructure.Persistence.UnitOfWork;

namespace Properties.Service.Infrastructure.Persistence.Extensions
{
    public class PersistenceOptions
    {
        public string ConnectionString { get; set; }
    }

    public static class PersistenceExtension
    {       
        public static void AddPersistence(this IServiceCollection services, Action<PersistenceOptions> configure)
        {
            var options = new PersistenceOptions();
            configure(options);

            services.AddDbContext<PropertiesContext>(o => o.UseSqlServer(options.ConnectionString));
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IImagerRepository, ImagerRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<PropertyUnitOfWork>();
        }
    }
}
