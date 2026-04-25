namespace LecturerManager.Application.CourseManagement.Dtos;

public record CourseDto(Guid Id, string Name, IReadOnlyList<AssignmentDto> Assignments);
