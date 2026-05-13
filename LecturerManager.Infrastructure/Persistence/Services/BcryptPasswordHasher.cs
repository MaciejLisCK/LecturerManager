using LecturerManager.Application.Common.Interfaces;

namespace LecturerManager.Infrastructure.Persistence.Services;

public class BcryptPasswordHasher : IPasswordHasher
{
    public string HashPassword(string password) =>
        BCrypt.Net.BCrypt.HashPassword(password);

    public bool VerifyPassword(string password, string hash) =>
        BCrypt.Net.BCrypt.Verify(password, hash);
}
