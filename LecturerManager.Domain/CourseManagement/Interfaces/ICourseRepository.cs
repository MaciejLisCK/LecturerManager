using LecturerManager.Domain.CourseManagement.Entities;

namespace LecturerManager.Domain.CourseManagement.Interfaces;

public interface ICourseRepository
{
    Task<Course?> GetByIdAsync(Guid courseId, CancellationToken cancellationToken = default);
}
