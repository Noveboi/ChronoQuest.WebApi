using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Infrastructure.Workers;

namespace ChronoQuest.Core.Domain;

/// <summary>
/// Tracks where the user is.
/// </summary>
public sealed class UserMarker : Entity
{
    private UserMarker() { }
    public UserMarker(Guid userId)
    {
        UserId = userId;
    }
    
    public Guid UserId { get; private init; }
    public Guid? ChapterId { get; private set; }
    public Guid? QuestionId { get; private set; }
    public Guid? ExamId { get; private set; }
    public Guid? ReviewId { get; private set; }

    public void Update(UpdateUserMarkerRequest request)
    {
        switch (request.Action)
        {
            case UserIs.ReadingChapter when ReviewId is null:
                Clear();
                ChapterId = request.EntityId;
                break;
            case UserIs.AnsweringQuestion when ReviewId is null:
                QuestionId = request.EntityId;
                break;
            case UserIs.TakingExam:
                Clear();
                ExamId = request.EntityId;
                break;
            case UserIs.ReviewingMaterial:
                Clear();
                ReviewId = request.EntityId;
                break;
            case UserIs.Done:
                Clear();
                break;
        }
    }

    private void Clear()
    {
        ChapterId = null;
        QuestionId = null;
        ExamId = null;
        ReviewId = null;
    } 
}