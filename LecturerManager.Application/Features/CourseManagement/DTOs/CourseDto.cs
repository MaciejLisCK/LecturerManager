namespace LecturerManager.Application.Features.CourseManagement.DTOs;

public record CourseDto(Guid Id, string Name, IReadOnlyList<AssignmentDto> Assignments);
