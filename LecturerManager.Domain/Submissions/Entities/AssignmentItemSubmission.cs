using LecturerManager.Domain.Shared;
using LecturerManager.Domain.Shared.Interfaces;

namespace LecturerManager.Domain.Submissions.Entities;

public abstract class AssignmentItemSubmission : Entity<Guid>, IAggregateRoot
{
    public Guid AssignmentItemId { get; private set; }

    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected AssignmentItemSubmission() { }

    protected AssignmentItemSubmission(Guid assignmentItemId)
    {
        Id = Guid.NewGuid();
        AssignmentItemId = assignmentItemId;
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
