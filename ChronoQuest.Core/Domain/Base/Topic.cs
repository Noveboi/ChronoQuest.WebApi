using ChronoQuest.Common;

namespace ChronoQuest.Core.Domain.Base;

public class Topic : Entity
{
    private Topic() { }
    public Topic(string name, Guid? id = null) : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; } = null!;
}