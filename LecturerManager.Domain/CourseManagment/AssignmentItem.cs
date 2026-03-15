namespace LecturerManager.Domain.CourseManagment;

public class AssignmentItem
{
    public Guid Id { get; init; }
    public string Name { get; private set; }

    private AssignmentItem() { }

    public AssignmentItem(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
