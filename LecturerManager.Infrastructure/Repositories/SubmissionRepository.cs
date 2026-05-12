using LecturerManager.Domain.Submissions.Entities;
using LecturerManager.Domain.Submissions.Interfaces;
using LecturerManager.Infrastructure.Persistence;

namespace LecturerManager.Infrastructure.Repositories;

public class SubmissionRepository(ApplicationDbContext dbContext) : ISubmissionRepository
{
    public async Task<AssignmentItemSubmission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await dbContext.AssignmentItemSubmissions.FindAsync([id], cancellationToken);

    public async Task AddAsync(AssignmentItemSubmission submission, CancellationToken cancellationToken = default) =>
        await dbContext.AssignmentItemSubmissions.AddAsync(submission, cancellationToken);
}
