using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Properties.Service.Domain.Entities;

namespace Properties.Service.Infrastructure.Persistence.Contexts.Configurations
{  
    public partial class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> entity)
        {
            entity.ToTable("Image");

            entity.Property(e => e.ImageId)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.File)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.Enable)
                .IsRequired()
                .HasMaxLength(1) 
                .IsUnicode(false);

            entity.HasOne(d => d.Property)
                .WithMany(p => p.Images)   
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK_Image_Property");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Image> entity);
    }
}
