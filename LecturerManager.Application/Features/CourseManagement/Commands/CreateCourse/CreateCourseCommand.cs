using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateCourse;

public record CreateCourseCommand(string Name) : IRequest<Guid>;
