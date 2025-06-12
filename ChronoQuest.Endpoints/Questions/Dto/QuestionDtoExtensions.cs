using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.Questions.Dto;

internal static class QuestionDtoExtensions
{
    public static QuestionDto ToDto(this Question question)
    {
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
            CorrectOptionId: question.Status switch
            {
                QuestionStatus.Unanswered => null,
                _ => question.CorrectOptionId
            },
            AnsweredOptionId: question.MostRecentAnswer()?.OptionId);
    }

    public static QuestionPreviewDto ToPreviewDto(this Question question)
    {
        return new QuestionPreviewDto(
            Id: question.Id,
            Number: question.Number,
            Type: question.Type.ToString().ToLowerInvariant(),
            Status: question.Status.ToString().ToLowerInvariant(),
            Topic: question.Topic.Name,
            Difficulty: question.Difficulty.ToDto());
    }

    public static TopicDto ToDto(this Topic topic)
    {
        return new TopicDto(topic.Id, topic.Name);
    }

    public static string ToDto(this QuestionStatus status) => status.ToString().ToLowerInvariant();
    public static string ToDto(this Difficulty diff) => diff.ToString().ToLowerInvariant();
}