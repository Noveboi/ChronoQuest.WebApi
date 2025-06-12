using System.Runtime.InteropServices.ComTypes;
using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Math;
using ChronoQuest.Core.Infrastructure;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ChronoQuest.Core.Application.Exams;

public sealed class ExamGenerator(ChronoQuestContext context, IAdaptiveLearning adaptiveLearning)
{
    public async Task<Exam> GenerateAsync(Guid userId, CancellationToken token)
    {
        var performancePerTopic = (await adaptiveLearning.GetPerformanceAsync(userId, token)).ToList();
        var questions = await DetermineExamQuestions(performancePerTopic, token);
        var examTime = DetermineExamTime(performancePerTopic, questions);

        return new Exam(
            userId: userId,
            questions: questions,
            timeLimit: examTime);
    }

    private async Task<List<Question>> DetermineExamQuestions(List<UserPerformanceForTopic> performanceForTopics, CancellationToken ct)
    {
        var decisions = performanceForTopics.Select(performanceForTopic =>
        {
            var questionNumber = 4;
            var progress = performanceForTopic.Performance.LearningProgress;
            var stability = performanceForTopic.Performance.ResponsePatterns.Stability;
            var efficiency = performanceForTopic.Performance.Efficiency;

            questionNumber += stability.IsStable ? 0 : 1;
            questionNumber += efficiency.Status switch
            {
                EfficiencyStatus.NeedsImprovement => 2,
                EfficiencyStatus.Good => 1,
                _ => 0
            };
            
            var decision = new TakeQuestionsForTopicDecision(performanceForTopic.Topic, questionNumber);

            return progress.State switch
            {
                LearningState.Struggling => decision.Distribute(90, 10, 0),
                LearningState.StrugglingButImproving => decision.Distribute(75, 25, 0),
                LearningState.ActiveLearning => decision.Distribute(50, 40, 10),
                LearningState.Mastering => decision.Distribute(25, 35, 50),
                LearningState.Mastered => decision.Distribute(0, 20, 80),
                _ => decision
            };
        });

        var questions = await decisions
            .ToAsyncEnumerable()
            .SelectMany(decision =>
            {
                return Enum.GetValues<Difficulty>()
                    .ToAsyncEnumerable()
                    .SelectMany(diff => context.Questions
                        .AsSplitQuery()
                        .ForTopic(decision.Topic.Id)
                        .WithoutChapter()
                        .HavingDifficulty(diff)
                        .PickRandom()
                        .Take(decision.NumberOfQuestionsFor(diff))
                        .AsAsyncEnumerable());
            })
            .ToListAsync(ct);

        return questions
            .OrderBy(_ => Random.Shared.Next())
            .ToList();
    }

    private static TimeSpan DetermineExamTime(List<UserPerformanceForTopic> performances, List<Question> questions)
    {
        var secondsPerQuestion = 60.0;
        var topicCount = performances.Count;
        
        foreach (var performanceForTopic in performances)
        {
            var progress = performanceForTopic.Performance.LearningProgress;
            var efficiency = performanceForTopic.Performance.Efficiency;
            var stability = performanceForTopic.Performance.ResponsePatterns.Stability;

            secondsPerQuestion += progress.State switch
            {   
                LearningState.Struggling => 60,
                LearningState.StrugglingButImproving => 30,
                LearningState.Plateau => 15,
                LearningState.Steady => 2.5,
                LearningState.Mastering => -5,
                LearningState.Mastered => -10,
                _ => 0
            } * progress.Confidence / topicCount;

            secondsPerQuestion += efficiency.Status switch
            {
                EfficiencyStatus.NeedsImprovement => 20,
                EfficiencyStatus.Excellent => -2.5,
                _ => 0
            } / topicCount;

            secondsPerQuestion += stability.IsStable ? 0 : (1 / stability.Value).Max(15);
        }

        var finalSecondsPerQuestions = secondsPerQuestion.Min(30).Max(140);
        return TimeSpan.FromSeconds(finalSecondsPerQuestions * questions.Count);
    }
}