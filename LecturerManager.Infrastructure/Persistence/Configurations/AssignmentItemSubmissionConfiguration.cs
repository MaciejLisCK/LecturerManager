using LecturerManager.Domain.Submissions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LecturerManager.Infrastructure.Persistence.Configurations;

public class AssignmentItemSubmissionConfiguration : IEntityTypeConfiguration<AssignmentItemSubmission>
{
    public void Configure(EntityTypeBuilder<AssignmentItemSubmission> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .HasDiscriminator<string>("submission_type")
            .HasValue<TextAssignmentItemSubmission>("text")
            .HasValue<ImageAssignmentItemSubmission>("image");
    }
}
