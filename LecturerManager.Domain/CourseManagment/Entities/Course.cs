using LecturerManager.Domain.CourseManagment.ValueObjects;

namespace LecturerManager.Domain.CourseManagment.Entities;

public class Course
{
    public Guid Id { get; init; }
    public CourseName Name { get; private set; } = null!;

    private readonly List<Assignment> _assignments = [];
    public IReadOnlyList<Assignment> Assignments => _assignments.AsReadOnly();

    private Course() { }

    public Course(CourseName name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid AddAssignment(AssignmentName name)
    {
        var assignment = new Assignment(this.Id, name);
        _assignments.Add(assignment);
        return assignment.Id;
    }
}
