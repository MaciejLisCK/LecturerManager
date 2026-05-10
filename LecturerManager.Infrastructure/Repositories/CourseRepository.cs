using LecturerManager.Domain.CourseManagement.Entities;
using LecturerManager.Domain.CourseManagement.Interfaces;
using LecturerManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LecturerManager.Infrastructure.Repositories;

public class CourseRepository(ApplicationDbContext dbContext) : ICourseRepository
{
    public async Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Courses
            .AsNoTracking()
            .AsSplitQuery()
            .Include(c => c.Assignments)
            .ThenInclude(a => a.AssignmentItems)
            .ToArrayAsync(cancellationToken);

    public async Task<Course?> GetByIdAsync(Guid courseId, CancellationToken cancellationToken = default) =>
        await dbContext.Courses
            .AsSplitQuery()
            .Include(c => c.Assignments)
            .ThenInclude(a => a.AssignmentItems)
            .SingleOrDefaultAsync(c => c.Id == courseId, cancellationToken);

    public async Task<Assignment?> GetAssignmentByIdAsync(Guid courseId, Guid assignmentId, CancellationToken cancellationToken = default) =>
        await dbContext.Courses
            .AsSplitQuery()
            .Where(c => c.Id == courseId)
            .SelectMany(c => c.Assignments)
            .Include(a => a.AssignmentItems)
            .SingleOrDefaultAsync(a => a.Id == assignmentId, cancellationToken);

    public async Task AddAsync(Course course, CancellationToken cancellationToken = default) =>
        await dbContext.Courses.AddAsync(course, cancellationToken);

    public async Task DeleteAsync(Guid courseId, CancellationToken cancellationToken = default)
    {
        await dbContext.Courses.Where(c => c.Id == courseId).ExecuteDeleteAsync(cancellationToken);
    }
}