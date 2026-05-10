namespace LecturerManager.Application.Features.CourseManagement.DTOs;

public record AssignmentDetailDto(Guid Id, string Name, IReadOnlyList<AssignmentItemDto> Items);
