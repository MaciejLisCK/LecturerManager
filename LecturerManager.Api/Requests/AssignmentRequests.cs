using LecturerManager.Domain.CourseManagement.ValueObjects;

namespace LecturerManager.Api.Requests;

public record CreateAssignmentRequest(string Name);
public record CreateAssignmentItemRequest(AssignmentItemType Type, string Name);
