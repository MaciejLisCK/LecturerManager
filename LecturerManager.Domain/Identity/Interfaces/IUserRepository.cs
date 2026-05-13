using LecturerManager.Domain.Identity.Entities;

namespace LecturerManager.Domain.Identity.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByLoginAsync(string login, CancellationToken cancellationToken = default);
    Task<bool> LoginExistsAsync(string login, CancellationToken cancellationToken = default);
    Task AddAsync(User user, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<User>> GetAllStudentsAsync(CancellationToken cancellationToken = default);
}
