using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data.Questions;

internal static class HistoryQuestions
{
    public static IEnumerable<Question> All()
    {
        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which civilization is considered Europe’s first advanced civilization and was based on the island of Crete?",
            correctOption: new Option("Minoan"),
            otherOptions:
            [
                new Option("Mycenaen"),
                new Option("Byzantine"),
                new Option("Roman")
            ],
            number: 1,
            type: QuestionType.Regular
        );
    }
}