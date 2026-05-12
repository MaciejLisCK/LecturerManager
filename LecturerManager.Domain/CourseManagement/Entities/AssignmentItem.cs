using LecturerManager.Domain.CourseManagement.ValueObjects;
using LecturerManager.Domain.Shared;

namespace LecturerManager.Domain.CourseManagement.Entities;

public class AssignmentItem : Entity<Guid>
{
    public AssignmentItemName Name { get; private set; } = null!;
    public AssignmentItemType ItemType { get; private set; }

    private AssignmentItem() { }

    public AssignmentItem(AssignmentItemName name, AssignmentItemType itemType)
    {
        Id = Guid.NewGuid();
        Name = name;
        ItemType = itemType;
    }
}
