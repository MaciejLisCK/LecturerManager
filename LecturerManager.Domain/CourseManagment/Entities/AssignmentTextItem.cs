using LecturerManager.Domain.CourseManagment.ValueObjects;

namespace LecturerManager.Domain.CourseManagment.Entities;

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