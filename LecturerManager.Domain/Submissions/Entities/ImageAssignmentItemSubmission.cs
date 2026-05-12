namespace LecturerManager.Domain.Submissions.Entities;

public class ImageAssignmentItemSubmission : AssignmentItemSubmission
{
    public string ImageUrl { get; private set; } = null!;

    private ImageAssignmentItemSubmission() { }

    public ImageAssignmentItemSubmission(Guid assignmentItemId, string imageUrl)
        : base(assignmentItemId)
    {
        ImageUrl = imageUrl;
    }
}
