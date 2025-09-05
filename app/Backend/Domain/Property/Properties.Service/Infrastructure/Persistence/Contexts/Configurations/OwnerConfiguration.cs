using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Properties.Service.Domain.Entities;

namespace Properties.Service.Infrastructure.Persistence.Contexts.Configurations
{
    public partial class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> entity)
        {
            entity.ToTable("Owner");

            entity.Property(e => e.OwnerId)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.Photo)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
           

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Owner> entity);
    }
}
