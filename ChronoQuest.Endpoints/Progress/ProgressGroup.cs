using FastEndpoints;

namespace ChronoQuest.Endpoints.Progress;

internal sealed class ProgressGroup : Group
{
    public ProgressGroup()
    {
        Configure("progress", _ => {});
    }
}