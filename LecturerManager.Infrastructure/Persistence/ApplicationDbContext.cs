using LecturerManager.Domain.CourseManagement.Entities;
using LecturerManager.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LecturerManager.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
	public DbSet<Course> Courses => Set<Course>();

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		modelBuilder.ApplyCustomNamingConventions();
	}
}
