using LecturerManager.Domain.CourseManagement.ValueObjects;

namespace LecturerManager.Domain.CourseManagement.Entities;

public class AssignmentImageItem : AssignmentItem
{
    public ImageUrl ImageUrl { get; private set; }

    private AssignmentImageItem() { }

    public AssignmentImageItem(AssignmentItemName name, ImageUrl imageUrl)
        : base(name)
    {
        ImageUrl = imageUrl;
    }
}
