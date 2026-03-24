using LecturerManager.Domain.CourseManagement.Entities;
using LecturerManager.Domain.CourseManagement.Interfaces;
using LecturerManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LecturerManager.Infrastructure.Repositories;

public class CourseRepository(ApplicationDbContext _db) : ICourseRepository
{
    public async Task<Course?> GetByIdAsync(Guid courseId, CancellationToken cancellationToken = default) =>
        await _db.Courses
            .Include(c => c.Assignments)
            .ThenInclude(a => a.AssignmentItems)
            .SingleOrDefaultAsync(c => c.Id == courseId, cancellationToken);
}
    