using LecturerManager.Domain.CourseManagment.Entities;

public class AssignmentImageItem : AssignmentItem
{
    public string ImageUrl { get; private set; }

    private AssignmentImageItem() { }

    public AssignmentImageItem(string name, string imageUrl)
        : base(name)
    {
        ImageUrl = imageUrl;
    }
}
