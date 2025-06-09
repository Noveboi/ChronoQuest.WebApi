using ChronoQuest.Endpoints.Chapters.Groups;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Questions.Groups;

internal sealed class QuestionGroup : SubGroup<ChapterQuestionGroup>
{
    public QuestionGroup() 
    {
        Configure("questions/{questionId:guid}", _ => { });
    }
}