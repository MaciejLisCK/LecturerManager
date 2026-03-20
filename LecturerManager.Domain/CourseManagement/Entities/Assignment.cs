using LecturerManager.Domain.CourseManagement.ValueObjects;

namespace LecturerManager.Domain.CourseManagement.Entities;

public class Assignment
{
    public Guid Id { get; init; }
    public Guid CourseId { get; init; }
    public AssignmentName Name { get; private set; }

    public Course Course { get; private set; } = null!;

    private readonly List<AssignmentItem> _assignmentItems = [];
    public IReadOnlyList<AssignmentItem> AssignmentItems => _assignmentItems.AsReadOnly();

    private Assignment() { }

    public Assignment(Guid courseId, AssignmentName name)
    {
        Id = Guid.NewGuid();
        CourseId = courseId;
        Name = name;
    }

    internal Guid AddTextItem(AssignmentItemName name, AssignmentTextItemText text)
    {
        var assignmentTextItem = new AssignmentTextItem(name, text);
        
        _assignmentItems.Add(assignmentTextItem);

        return assignmentTextItem.Id;
    }
}
