using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Properties.Service.Domain.Entities;
using System.Collections.Generic;

namespace Properties.Service.Infrastructure.Persistence.Contexts
{
    public partial class PropertiesContext : DbContext
    {
        public PropertiesContext(DbContextOptions<PropertiesContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ImageConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
