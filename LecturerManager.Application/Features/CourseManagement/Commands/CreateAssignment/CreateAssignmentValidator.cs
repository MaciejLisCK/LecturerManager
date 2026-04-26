using FluentValidation;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignment;

public class CreateAssignmentValidator : AbstractValidator<CreateAssignmentCommand>
{
    public CreateAssignmentValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(300);
    }
}