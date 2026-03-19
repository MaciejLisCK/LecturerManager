using LecturerManager.Domain.CourseManagment.ValueObjects;

namespace LecturerManager.Domain.CourseManagment.Entities;

public class Assignment
{
    public Guid Id { get; init; }
    public Guid CourseId { get; init; }
    public AssignmentName Name { get; private set; }

    public Course Course { get; private set; } = null!;

    private readonly List<AssignmentItem> _assignmentItems = [];
    public IReadOnlyList<AssignmentItem> AssignmentItemDefinitions => _assignmentItems.AsReadOnly();

    private Assignment() { }

    public Assignment(Guid courseId, AssignmentName name)
    {
        Id = Guid.NewGuid();
        CourseId = courseId;
        Name = name;
    }
}
