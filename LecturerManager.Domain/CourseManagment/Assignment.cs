namespace LecturerManager.Domain.CourseManagment;

public class Assignment
{
    public Guid Id { get; init; }
    public Guid CourseId { get; init; }


    public Course Course { get; private set; } = null!;

    private readonly List<AssignmentItem> _assignmentItems = [];
    public IReadOnlyList<AssignmentItem> AssignmentItemDefinitions { get; };


    private Assignment() { }

    public Assignment(Guid courseId)
    {
        Id = Guid.NewGuid();
        CourseId = courseId;
        AssignmentItemDefinitions = _assignmentItems.AsReadOnly();
    }
}
