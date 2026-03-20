using LecturerManager.Domain.CourseManagement.ValueObjects;

namespace LecturerManager.Domain.CourseManagement.Entities;

public class AssignmentTextItem : AssignmentItem
{
    public AssignmentTextItemText Text { get; private set; }
    
    private AssignmentTextItem() { }

    public AssignmentTextItem(AssignmentItemName name, AssignmentTextItemText text)
        : base(name)
    {
        Text = text;
    }
}