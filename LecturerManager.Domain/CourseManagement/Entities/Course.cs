using LecturerManager.Domain.CourseManagement.Events;
using LecturerManager.Domain.CourseManagement.Exceptions;
using LecturerManager.Domain.CourseManagement.ValueObjects;
using LecturerManager.Domain.Shared;
using LecturerManager.Domain.Shared.Interfaces;

namespace LecturerManager.Domain.CourseManagement.Entities;

public class Course : Entity<Guid>, IAggregateRoot
{
    public CourseName Name { get; private set; } = null!;

    private readonly List<Assignment> _assignments = [];
    public IReadOnlyList<Assignment> Assignments => _assignments.AsReadOnly();

    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    private Course() { }

    public Course(CourseName name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid AddAssignment(AssignmentName name)
    {
        var assignment = new Assignment(this.Id, name);
        _assignments.Add(assignment);
        _domainEvents.Add(new AssignmentCreatedDomainEvent(Id, assignment.Id));
        return assignment.Id;
    }

    public Guid AddAssignmentTextItem(Guid assignmentId, AssignmentItemName name, AssignmentTextItemText text)
    {
        var assignment = _assignments.SingleOrDefault(a => a.Id == assignmentId);
        if (assignment is null)
            throw new AssignmentNotFoundException(assignmentId);

        var assignmentTextItemId = assignment.AddTextItem(name, text);

        return assignmentTextItemId;
    }

    public void RemoveAssignment(Guid assignmentId)
    {
        var assignment = _assignments.SingleOrDefault(a => a.Id == assignmentId);
        if (assignment is null)
            throw new AssignmentNotFoundException(assignmentId);

        _assignments.Remove(assignment);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
