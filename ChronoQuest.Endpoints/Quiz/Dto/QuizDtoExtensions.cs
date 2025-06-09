using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Endpoints.Quiz.Dto;

internal static class QuizDtoExtensions
{
    public static QuestionDto ToDto(this Question question)
    {
        return new QuestionDto(
            Content: question.Content,
            Options: question.Options);
    }
}