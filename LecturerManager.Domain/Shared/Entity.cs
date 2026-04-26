namespace LecturerManager.Domain.Shared;

public abstract class Entity<TId>
{
    public TId Id { get; protected init; } = default!;

    protected Entity() { }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id!.Equals(other.Id);
    }

    public override int GetHashCode() => Id!.GetHashCode();

    public static bool operator ==(Entity<TId>? a, Entity<TId>? b)
        => a is null ? b is null : a.Equals(b);

    public static bool operator !=(Entity<TId>? a, Entity<TId>? b) => !(a == b);
}