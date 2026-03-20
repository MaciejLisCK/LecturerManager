using LecturerManager.Domain.CourseManagement.Exceptions;
using LecturerManager.Domain.CourseManagement.ValueObjects;

namespace LecturerManager.Domain.CourseManagement.Entities;

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

    public Guid AddAssigmentTextItem(Guid assignmentId, AssignmentItemName name, AssignmentTextItemText text)
    {
        var assignmentTextItem = new AssignmentTextItem(name, text);

        var assignment = _assignments.SingleOrDefault(a => a.Id == assignmentId);
        if (assignment is null)
            throw new AssignmentNotFoundException(assignmentId);

        var assignmentTextItemId = assignment.AddTextItem(name, text);

        return assignmentTextItemId;
    }
}
