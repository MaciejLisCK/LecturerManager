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

		modelBuilder.Entity<AssignmentItem>()
			.HasDiscriminator<string>("item_type")
			.HasValue<AssignmentTextItem>("text")
			.HasValue<AssignmentImageItem>("image");

		modelBuilder.Entity<AssignmentItem>()
			.OwnsOne(x => x.Name, modelBuilder =>
			{
				modelBuilder.Property(x => x.Value)
					.HasColumnName("Name");
			});

		modelBuilder.Entity<Course>()
			.OwnsOne(x => x.Name, modelBuilder =>
			{
				modelBuilder.Property(x => x.Value)
					.HasColumnName("Name");
			});

		modelBuilder.Entity<Assignment>()
			.OwnsOne(x => x.Name, modelBuilder =>
			{
				modelBuilder.Property(x => x.Value)
					.HasColumnName("Name");
			});

		modelBuilder.Entity<AssignmentImageItem>()
			.OwnsOne(x => x.ImageUrl, modelBuilder =>
			{
				modelBuilder.Property(x => x.Value)
					.HasColumnName("ImageUrl");
			});

		modelBuilder.Entity<AssignmentTextItem>()
			.OwnsOne(x => x.Text, modelBuilder =>
			{
				modelBuilder.Property(x => x.Value)
					.HasColumnName("Text");
			});

		// modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		modelBuilder.ApplyCustomNamingConventions();
	}
}
