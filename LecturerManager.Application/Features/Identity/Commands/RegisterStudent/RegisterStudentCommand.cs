using MediatR;

namespace LecturerManager.Application.Features.Identity.Commands.RegisterStudent;

public record RegisterStudentCommand(
    string Login,
    string Password,
    string EncryptedFirstName,
    string EncryptedLastName,
    string EncryptedStudentIndex,
    string EncryptedEmail) : IRequest<Guid>;
