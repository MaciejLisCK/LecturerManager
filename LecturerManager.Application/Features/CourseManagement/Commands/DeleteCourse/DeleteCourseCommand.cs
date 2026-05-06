using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.DeleteCourse;

public record DeleteCourseCommand(Guid Id) : IRequest;
