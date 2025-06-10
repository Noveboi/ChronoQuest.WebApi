namespace ChronoQuest.Core.Domain;

public abstract class Entity
{
    protected Entity() => Id = Guid.CreateVersion7();
    protected Entity(Guid? id) => Id = id ?? Guid.CreateVersion7();

    public Guid Id { get; private init; }

    public static bool operator ==(Entity? a, Entity? b) 
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity? a, Entity? b) => !(a == b);

    public override bool Equals(object? obj)
    {
        if (obj is not Entity entity)
            return false;

        return entity.Id == Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}