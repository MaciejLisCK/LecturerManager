using FluentValidation;

namespace LecturerManager.Application.Features.Identity.Commands.LoginStudent;

public class LoginStudentValidator : AbstractValidator<LoginStudentCommand>
{
    public LoginStudentValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(200);
    }
}