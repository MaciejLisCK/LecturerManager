using LecturerManager.Domain.Identity.Entities;
using LecturerManager.Domain.Identity.Enums;
using LecturerManager.Domain.Identity.Interfaces;
using LecturerManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LecturerManager.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetByLoginAsync(string login, CancellationToken cancellationToken = default) =>
        await dbContext.Users
            .SingleOrDefaultAsync(u => u.Login == login, cancellationToken);

    public async Task<bool> LoginExistsAsync(string login, CancellationToken cancellationToken = default) =>
        await dbContext.Users
            .AnyAsync(u => u.Login == login, cancellationToken);

    public async Task AddAsync(User user, CancellationToken cancellationToken = default) =>
        await dbContext.Users.AddAsync(user, cancellationToken);

    public async Task<IReadOnlyList<User>> GetAllStudentsAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Users
            .AsNoTracking()
            .Where(u => u.Role == UserRole.Student)
            .ToArrayAsync(cancellationToken);
}
