using LecturerManager.Domain.CourseManagment.Entities;
using Microsoft.EntityFrameworkCore;

namespace LecturerManager.Infrastructure.Persistance;

public class ApplicationDbContext : DbContext
{
	public DbSet<Course> Courses => Set<Course>();

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{ }
}
