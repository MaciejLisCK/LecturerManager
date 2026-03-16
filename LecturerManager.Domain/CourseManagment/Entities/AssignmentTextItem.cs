using LecturerManager.Domain.CourseManagment.Entities;

public class AssignmentTextItem : AssignmentItem
{
    public string Text { get; private set; }
    
    private AssignmentTextItem() { }

    public AssignmentTextItem(string name, string text)
        : base(name)
    {
        Text = text;
    }
}