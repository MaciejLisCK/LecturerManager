using MediatR;

namespace LecturerManager.Application.Features.Identity.Commands.LoginStudent;

public record LoginStudentCommand(string Login, string Password) : IRequest<LoginStudentResponse>;

public record LoginStudentResponse(string AccessToken, string Role);