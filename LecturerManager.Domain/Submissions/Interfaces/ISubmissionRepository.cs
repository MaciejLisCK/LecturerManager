using LecturerManager.Domain.Submissions.Entities;

namespace LecturerManager.Domain.Submissions.Interfaces;

public interface ISubmissionRepository
{
    Task<AssignmentItemSubmission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(AssignmentItemSubmission submission, CancellationToken cancellationToken = default);
}
