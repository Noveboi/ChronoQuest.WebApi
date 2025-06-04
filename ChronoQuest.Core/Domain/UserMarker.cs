using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Infrastructure.Workers;

namespace ChronoQuest.Core.Domain;

/// <summary>
/// Tracks the user's progress
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

    public void Update(UpdateUserMarkerRequest request)
    {
        switch (request.Action)
        {
            case UserIs.ReadingChapter:
                Clear();
                ChapterId = request.EntityId;
                break;
            case UserIs.AnsweringQuestion:
                ExamId = null;
                QuestionId = request.EntityId;
                break;
            case UserIs.TakingExam:
                Clear();
                ExamId = request.EntityId;
                break;
            default:
                throw new NotSupportedException(request.Action.ToString());
        }
    }

    private void Clear()
    {
        ChapterId = null;
        QuestionId = null;
        ExamId = null;
    } 
}