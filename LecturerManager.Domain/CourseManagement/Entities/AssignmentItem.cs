using LecturerManager.Domain.CourseManagement.ValueObjects;
using LecturerManager.Domain.Shared;

namespace LecturerManager.Domain.CourseManagement.Entities;

public class AssignmentItem : Entity<Guid>
{
    public AssignmentItemName Name { get; private set; }

    protected AssignmentItem() { }

    public AssignmentItem(AssignmentItemName name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
