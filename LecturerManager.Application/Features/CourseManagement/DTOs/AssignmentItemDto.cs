using LecturerManager.Domain.CourseManagement.ValueObjects;

namespace LecturerManager.Application.Features.CourseManagement.DTOs;

public record AssignmentItemDto(Guid Id, string Name, AssignmentItemType ItemType);
