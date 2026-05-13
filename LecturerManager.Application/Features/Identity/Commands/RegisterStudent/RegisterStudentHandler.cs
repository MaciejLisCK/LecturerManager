using LecturerManager.Application.Common.Interfaces;
using LecturerManager.Domain.Identity.Entities;
using LecturerManager.Domain.Identity.Exceptions;
using LecturerManager.Domain.Identity.Interfaces;
using LecturerManager.Domain.Shared.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.Identity.Commands.RegisterStudent;

public class RegisterStudentHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork)
    : IRequestHandler<RegisterStudentCommand, Guid>
{
    public async Task<Guid> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.LoginExistsAsync(request.Login, cancellationToken))
            throw new LoginAlreadyExistsException(request.Login);

        var passwordHash = passwordHasher.HashPassword(request.Password);

        var user = User.RegisterStudent(
            request.Login,
            passwordHash,
            request.EncryptedFirstName,
            request.EncryptedLastName,
            request.EncryptedStudentIndex,
            request.EncryptedEmail);

        await userRepository.AddAsync(user, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
