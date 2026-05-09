using LecturerManager.Domain.CourseManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LecturerManager.Infrastructure.Persistence.Configurations;

public class AssignmentItemConfiguration : IEntityTypeConfiguration<AssignmentItem>
{
    public void Configure(EntityTypeBuilder<AssignmentItem> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .HasDiscriminator<string>("item_type")
            .HasValue<AssignmentTextItem>("text")
            .HasValue<AssignmentImageItem>("image");

        builder
            .OwnsOne(x => x.Name, modelBuilder =>
            {
                modelBuilder.Property(x => x.Value)
                    .HasColumnName("Name");
            });
    }
}