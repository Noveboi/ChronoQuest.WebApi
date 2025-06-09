using ChronoQuest.Core.Application.Questions;

namespace ChronoQuest.Endpoints.Questions.Dto;

internal static class QuizDtoExtensions
{
    public static QuestionDto ToDto(this QuestionResponse resp)
    {
        var question = resp.Question;
        
        return new QuestionDto(
            Id: question.Id,
            Number: question.Number,
            Topic: question.Topic.Name,
            Type: question.Type.ToString(),
            Status: resp.Status.ToString(),
            Content: question.Content,
            Options: question.Options);
    }
}