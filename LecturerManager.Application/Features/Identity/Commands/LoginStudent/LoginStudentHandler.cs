using LecturerManager.Application.Common.Interfaces;
using LecturerManager.Domain.Identity.Enums;
using LecturerManager.Domain.Identity.Exceptions;
using LecturerManager.Domain.Identity.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.Identity.Commands.LoginStudent;

public class LoginStudentHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<LoginStudentCommand, LoginStudentResponse>
{
    public async Task<LoginStudentResponse> Handle(LoginStudentCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByLoginAsync(request.Login, cancellationToken);
        if (user is null)
            throw new InvalidCredentialsException();

        var isValidPassword = passwordHasher.VerifyPassword(request.Password, user.PasswordHash);
        if (!isValidPassword || user.Role != UserRole.Student)
            throw new InvalidCredentialsException();

        var token = jwtTokenGenerator.GenerateToken(user.Id, user.Login, user.Role);
        return new LoginStudentResponse(token, user.Role.ToString().ToLowerInvariant());
    }
}