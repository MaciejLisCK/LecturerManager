using LecturerManager.Domain.Identity.Enums;

namespace LecturerManager.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string login, UserRole role);
}