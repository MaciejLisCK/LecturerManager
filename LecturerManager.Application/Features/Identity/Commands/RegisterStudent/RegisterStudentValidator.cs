using FluentValidation;

namespace LecturerManager.Application.Features.Identity.Commands.RegisterStudent;

public class RegisterStudentValidator : AbstractValidator<RegisterStudentCommand>
{
    public RegisterStudentValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(200);

        RuleFor(x => x.EncryptedFirstName)
            .NotEmpty();

        RuleFor(x => x.EncryptedLastName)
            .NotEmpty();

        RuleFor(x => x.EncryptedStudentIndex)
            .NotEmpty();

        RuleFor(x => x.EncryptedEmail)
            .NotEmpty();
    }
}
