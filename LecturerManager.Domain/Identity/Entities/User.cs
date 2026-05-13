using LecturerManager.Domain.Identity.Enums;
using LecturerManager.Domain.Shared;

namespace LecturerManager.Domain.Identity.Entities;

public class User : Entity<Guid>
{
    public string Login { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public UserRole Role { get; private set; }

    // Encrypted personal data (Base64-encoded, encrypted on frontend with RSA-OAEP).
    // Null for Teacher accounts.
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? StudentIndex { get; private set; }
    public string? Email { get; private set; }

    private User() { }

    public static User CreateTeacher(Guid id, string login, string passwordHash)
    {
        return new User
        {
            Id = id,
            Login = login,
            PasswordHash = passwordHash,
            Role = UserRole.Teacher
        };
    }

    public static User RegisterStudent(
        string login,
        string passwordHash,
        string encryptedFirstName,
        string encryptedLastName,
        string encryptedStudentIndex,
        string encryptedEmail)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            Login = login,
            PasswordHash = passwordHash,
            Role = UserRole.Student,
            FirstName = encryptedFirstName,
            LastName = encryptedLastName,
            StudentIndex = encryptedStudentIndex,
            Email = encryptedEmail
        };
    }
}
