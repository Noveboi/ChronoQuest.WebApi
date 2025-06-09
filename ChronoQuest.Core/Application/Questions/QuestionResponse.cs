using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Application.Questions;

public sealed class QuestionResponse
{
    internal QuestionResponse(Question question)
    {
        Question = question;

        Status = question.Answers switch
        {
            [] => QuestionStatus.Unanswered,
            [.., { IsCorrect: true }] => QuestionStatus.Correct,
            [.., { IsCorrect: false }] => QuestionStatus.Wrong
        };
    }
    
    public Question Question { get; }
    public QuestionStatus Status { get; }

    public QuestionAnswer? GetLastGivenAnswer() => Question.Answers.LastOrDefault();
}