namespace LecturerManager.Domain.CourseManagment.Entities;

public class AssignmentItem
{
    public Guid Id { get; init; }
    public string Name { get; private set; }

    protected AssignmentItem() { }

    public AssignmentItem(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
