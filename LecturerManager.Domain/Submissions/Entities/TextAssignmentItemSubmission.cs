namespace LecturerManager.Domain.Submissions.Entities;

public class TextAssignmentItemSubmission : AssignmentItemSubmission
{
    public string Text { get; private set; } = null!;

    private TextAssignmentItemSubmission() { }

    public TextAssignmentItemSubmission(Guid assignmentItemId, string text)
        : base(assignmentItemId)
    {
        Text = text;
    }
}
