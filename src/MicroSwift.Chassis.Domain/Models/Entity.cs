namespace MicroSwift.Chassis.Domain.Models;

public abstract class Entity<T>
{
    public T Id { get; protected set; }

    protected Entity() { }

    protected Entity(T id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        Id = id;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Entity<T> other))
            return false;

        return GetType() == other.GetType() && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
    }
}
