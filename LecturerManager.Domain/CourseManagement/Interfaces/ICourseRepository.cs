using LecturerManager.Domain.CourseManagement.Entities;

namespace LecturerManager.Domain.CourseManagement.Interfaces;

public interface ICourseRepository
{
    Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Course?> GetByIdAsync(Guid courseId, CancellationToken cancellationToken = default);
}
