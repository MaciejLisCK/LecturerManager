using LecturerManager.Domain.Identity.Entities;
using LecturerManager.Domain.Identity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LecturerManager.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private static readonly Guid TeacherSeedId = new("a1b2c3d4-e5f6-7890-abcd-ef1234567890");
    private const string TeacherLogin = "admin";
    private const string TeacherPasswordHash = "$2a$11$8MqFe/099pa66yV3/J021eAcc6e1BI/spqZ.8UbzxPFeNC2iEFjzm";

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Login)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.Login)
            .IsUnique();

        builder.Property(x => x.PasswordHash)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Role)
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasMaxLength(1024);

        builder.Property(x => x.LastName)
            .HasMaxLength(1024);

        builder.Property(x => x.StudentIndex)
            .HasMaxLength(1024);

        builder.Property(x => x.Email)
            .HasMaxLength(1024);

        // Seed teacher account
        builder.HasData(User.CreateTeacher(TeacherSeedId, TeacherLogin, TeacherPasswordHash));
    }
}
