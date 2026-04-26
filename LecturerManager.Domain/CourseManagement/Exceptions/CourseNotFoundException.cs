using LecturerManager.Domain.Shared.Exceptions;

namespace LecturerManager.Domain.CourseManagement.Exceptions;

public sealed class CourseNotFoundException(Guid courseId) : DomainException($"Course with ID '{courseId}' was not found.")
{ }