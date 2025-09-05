using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Properties.Service.Domain.Entities;

namespace Properties.Service.Infrastructure.Persistence.Contexts.Configurations
{
    public partial class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> entity)
        {
            entity.ToTable("Property");

            entity.Property(e => e.PropertyId)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Name)
                .IsRequired();

            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,3)");

            entity.Property(e => e.CodeInternal)
               .IsRequired()
               .HasMaxLength(20);

            // 🔗 Relación muchos a uno (Property → Owner)
            entity.HasOne(d => d.Owner)
                .WithMany(p => p.Properties)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Property_Owner");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Property> entity);
    }
}
