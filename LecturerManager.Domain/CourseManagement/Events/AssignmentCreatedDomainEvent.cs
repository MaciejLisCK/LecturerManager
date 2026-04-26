using LecturerManager.Domain.Shared.Interfaces;

namespace LecturerManager.Domain.CourseManagement.Events;

public record AssignmentCreatedDomainEvent(Guid CourseId, Guid AssignmentId) : IDomainEvent;