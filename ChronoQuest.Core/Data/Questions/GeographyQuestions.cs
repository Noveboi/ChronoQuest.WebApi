using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data.Questions;

internal static class GeographyQuestions
{
    public static IEnumerable<Question> ForQuiz()
    {
        // 15 questions for the quiz; last 4 are skippable

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Easy,
            content: "What is the largest island in Greece?",
            correctOption: new Option("Crete"),
            otherOptions:
            [
                new Option("Rhodes"),
                new Option("Euboea"),
                new Option("Corfu")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "Approximately how many kilometers does Crete stretch from west to east?",
            correctOption: new Option("260 km"),
            otherOptions:
            [
                new Option("150 km"),
                new Option("350 km"),
                new Option("100 km")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Hard,
            content: "What is the narrowest width of Crete at the Selinous Gulf?",
            correctOption: new Option("12 km"),
            otherOptions:
            [
                new Option("20 km"),
                new Option("5 km"),
                new Option("30 km")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "Which mountain range contains Mount Ida, the highest peak on Crete?",
            correctOption: new Option("Psilorítis Range"),
            otherOptions:
            [
                new Option("White Mountains"),
                new Option("Dikti Mountains"),
                new Option("Lefka Ori")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Easy,
            content: "What is the local name for the White Mountains of western Crete?",
            correctOption: new Option("Lefká Óri"),
            otherOptions:
            [
                new Option("Omalós"),
                new Option("Lasíthi"),
                new Option("Selinous")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "Which high plateau in eastern Crete is famous for its windmills?",
            correctOption: new Option("Lasíthi Plateau"),
            otherOptions:
            [
                new Option("Omalós Plateau"),
                new Option("Chania Plain"),
                new Option("Psilorítis Plateau")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "What is the name of Europe’s longest gorge, located on Crete?",
            correctOption: new Option("Samariá Gorge"),
            otherOptions:
            [
                new Option("Imbros Gorge"),
                new Option("Kourtaliotiko Gorge"),
                new Option("Ha Gorge")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Hard,
            content: "Which coastal plain is renowned for its fertile soils and olive groves near the city of Heraklion?",
            correctOption: new Option("The Heraklion Plain"),
            otherOptions:
            [
                new Option("Lasíthi Plain"),
                new Option("Chania Plain"),
                new Option("Rethymno Plain")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Easy,
            content: "What type of climate does Crete experience?",
            correctOption: new Option("Mediterranean"),
            otherOptions:
            [
                new Option("Continental"),
                new Option("Oceanic"),
                new Option("Tropical")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "In which part of Crete does annual rainfall drop below 400 mm?",
            correctOption: new Option("Eastern Crete"),
            otherOptions:
            [
                new Option("Western Crete"),
                new Option("Central Crete"),
                new Option("Northern Crete")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Easy,
            content: "What is the name of the endemic wild goat found in Crete?",
            correctOption: new Option("Kri‑kri"),
            otherOptions:
            [
                new Option("Chamois"),
                new Option("Ibex"),
                new Option("Capra aegagrus")
            ],
            
            type: QuestionType.Regular
        );

        // Skippable questions start here
        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Hard,
            content: "Which seagrass species forms important underwater meadows around Crete?",
            correctOption: new Option("Posidonia oceanica"),
            otherOptions:
            [
                new Option("Zostera marina"),
                new Option("Cymodocea nodosa"),
                new Option("Halophila stipulacea")
            ],
            
            type: QuestionType.Skippable
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Easy,
            content: "Which famous pink-sand beach is located on the southwestern coast of Crete?",
            correctOption: new Option("Elafonisi"),
            otherOptions:
            [
                new Option("Balos"),
                new Option("Falassarna"),
                new Option("Vai Beach")
            ],
            
            type: QuestionType.Skippable
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "By which sea does the southern coast of Crete border?",
            correctOption: new Option("Libyan Sea"),
            otherOptions:
            [
                new Option("Aegean Sea"),
                new Option("Ionian Sea"),
                new Option("Mediterranean Sea")
            ],
            
            type: QuestionType.Skippable
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Hard,
            content: "Which cave on Mount Dikti is associated with the mythological birthplace of Zeus?",
            correctOption: new Option("Diktaean Cave"),
            otherOptions:
            [
                new Option("Idean Cave"),
                new Option("Melidoni Cave"),
                new Option("Seitan Limania Cave")
            ],
            
            type: QuestionType.Skippable
        );
    }

    public static IEnumerable<Question> ForExam()
    {
        // 12 exam questions: 4 Easy, 4 Medium, 4 Hard

        // 4 Easy
        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Easy,
            content: "What is the largest island in Greece?",
            correctOption: new Option("Crete"),
            otherOptions:
            [
                new Option("Rhodes"),
                new Option("Euboea"),
                new Option("Corfu")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Easy,
            content: "What type of climate does Crete experience?",
            correctOption: new Option("Mediterranean"),
            otherOptions:
            [
                new Option("Continental"),
                new Option("Oceanic"),
                new Option("Tropical")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Easy,
            content: "What is the name of the endemic wild goat found in Crete?",
            correctOption: new Option("Kri‑kri"),
            otherOptions:
            [
                new Option("Chamois"),
                new Option("Ibex"),
                new Option("Capra aegagrus")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Easy,
            content: "Which high plateau in eastern Crete is famous for its windmills?",
            correctOption: new Option("Lasíthi Plateau"),
            otherOptions:
            [
                new Option("Omalós Plateau"),
                new Option("Chania Plain"),
                new Option("Psilorítis Plateau")
            ],
            
            type: QuestionType.Regular
        );

        // 4 Medium
        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "Approximately how many kilometers does Crete stretch from west to east?",
            correctOption: new Option("260 km"),
            otherOptions:
            [
                new Option("150 km"),
                new Option("350 km"),
                new Option("100 km")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "Which mountain range contains Mount Ida, the highest peak on Crete?",
            correctOption: new Option("Psilorítis (Ida) Range"),
            otherOptions:
            [
                new Option("White Mountains"),
                new Option("Dikti Mountains"),
                new Option("Lefka Ori")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "In which part of Crete does annual rainfall drop below 400 mm?",
            correctOption: new Option("Eastern Crete"),
            otherOptions:
            [
                new Option("Western Crete"),
                new Option("Central Crete"),
                new Option("Northern Crete")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Medium,
            content: "What is the name of Europe’s longest gorge, located on Crete?",
            correctOption: new Option("Samariá Gorge"),
            otherOptions:
            [
                new Option("Imbros Gorge"),
                new Option("Kourtaliotiko Gorge"),
                new Option("Ha Gorge")
            ],
            
            type: QuestionType.Regular
        );

        // 4 Hard
        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Hard,
            content: "What is the narrowest width of Crete at the Selinous Gulf?",
            correctOption: new Option("12 km"),
            otherOptions:
            [
                new Option("20 km"),
                new Option("5 km"),
                new Option("30 km")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Hard,
            content: "Which seagrass species forms important underwater meadows around Crete?",
            correctOption: new Option("Posidonia oceanica"),
            otherOptions:
            [
                new Option("Zostera marina"),
                new Option("Cymodocea nodosa"),
                new Option("Halophila stipulacea")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Hard,
            content: "Which famous pink-sand beach is located on the southwestern coast of Crete?",
            correctOption: new Option("Elafonisi"),
            otherOptions:
            [
                new Option("Balos"),
                new Option("Falassarna"),
                new Option("Vai Beach")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Geography,
            difficulty: Difficulty.Hard,
            content: "Which cave on Mount Dikti is associated with the mythological birthplace of Zeus?",
            correctOption: new Option("Diktaean Cave"),
            otherOptions:
            [
                new Option("Idean Cave"),
                new Option("Melidoni Cave"),
                new Option("Seitan Limania Cave")
            ],
            
            type: QuestionType.Regular
        );
    }
}
