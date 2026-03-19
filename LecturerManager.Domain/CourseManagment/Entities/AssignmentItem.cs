using LecturerManager.Domain.CourseManagment.ValueObjects;

namespace LecturerManager.Domain.CourseManagment.Entities;

public class AssignmentItem
{
    public Guid Id { get; init; }
    public AssignmentItemName Name { get; private set; }

    protected AssignmentItem() { }

    public AssignmentItem(AssignmentItemName name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
