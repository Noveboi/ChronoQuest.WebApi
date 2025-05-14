using FastEndpoints;

namespace ChronoQuest.Endpoints.Quiz;

internal sealed class QuestionGroup : SubGroup<QuizGroup>
{
    public QuestionGroup() 
    {
        Configure("questions/{questionId:guid}", _ => { });
    }
}