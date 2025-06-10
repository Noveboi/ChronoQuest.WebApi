using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.Questions.Dto;

internal static class QuestionDtoExtensions
{
    public static QuestionDto ToDto(this QuestionResponse resp)
    {
        var question = resp.Question;

        if (question.Topic is null)
        {
            throw new InvalidOperationException("Question topic is null!. Be sure to Include() in your query.");
        }

        if (question.Options.Count != 4)
        {
            throw new InvalidOperationException("Question options must be 4!");
        }
        
        return new QuestionDto(
            Id: question.Id,
            Number: question.Number,
            Topic: question.Topic.ToDto(),
            Type: question.Type.ToString().ToLowerInvariant(),
            Content: question.Content,
            Options: question.Options.Select(x => new OptionDto(
                Id: x.Id,
                Title: x.Content)),
            CorrectOptionId: resp.Status switch
            {
                QuestionStatus.Unanswered => null,
                _ => question.CorrectOptionId
            },
            AnsweredOptionId: resp.GetLastGivenAnswer()?.OptionId);
    }

    public static QuestionPreviewDto ToPreviewDto(this QuestionResponse resp)
    {
        var question = resp.Question;

        return new QuestionPreviewDto(
            Id: question.Id,
            Number: question.Number,
            Type: question.Type.ToString().ToLowerInvariant(),
            Status: resp.Status.ToString().ToLowerInvariant());
    }

    public static TopicDto ToDto(this Topic topic)
    {
        return new TopicDto(topic.Id, topic.Name);
    }
}