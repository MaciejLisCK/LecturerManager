using FluentValidation;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignmentItem;

public class CreateAssignmentItemValidator : AbstractValidator<CreateAssignmentItemCommand>
{
    public CreateAssignmentItemValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty();

        RuleFor(x => x.AssignmentId)
            .NotEmpty();

        RuleFor(x => x.Type)
            .IsInEnum();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(300);
    }
}
