using LecturerManager.Domain.Shared.Interfaces;

namespace LecturerManager.Infrastructure.Persistence;

public class EfUnitOfWork(ApplicationDbContext db) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => db.SaveChangesAsync(cancellationToken);
}
