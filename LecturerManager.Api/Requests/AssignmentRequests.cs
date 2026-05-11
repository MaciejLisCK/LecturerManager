using LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignmentItem;

namespace LecturerManager.Api.Requests;

public record CreateAssignmentRequest(string Name);
public record CreateAssignmentItemRequest(AssignmentItemType Type, string Name, string? Text, string? ImageUrl);
