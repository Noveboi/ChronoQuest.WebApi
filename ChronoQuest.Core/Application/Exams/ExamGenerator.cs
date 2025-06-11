using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Exams;

public sealed class ExamGenerator
{
    public Task<Exam> GenerateAsync(Guid userId, CancellationToken token)
    {
        // 1. Get BKTs for user
        // 2. Get question stats for user
        // 3. Determine exam time limit
        // 4. Determine exam questions 
        throw new NotImplementedException();
    }
}