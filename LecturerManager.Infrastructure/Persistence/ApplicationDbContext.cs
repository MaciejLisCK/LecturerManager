using LecturerManager.Domain.CourseManagement.Entities;
using LecturerManager.Domain.Submissions.Entities;
using LecturerManager.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LecturerManager.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
	public DbSet<Course> Courses => Set<Course>();
	public DbSet<AssignmentItemSubmission> AssignmentItemSubmissions => Set<AssignmentItemSubmission>();

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		modelBuilder.ApplyCustomNamingConventions();
	}

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(cancellationToken);
}
