using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data.Questions;

internal static class CultureQuestions
{
    public static IEnumerable<Question> ForQuiz()
    {
        // 15 questions for the quiz; last 4 are skippable

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Easy,
            content: "What term describes the traditional Cretan value of generous hospitality to guests?",
            correctOption: new Option("Philoxenia"),
            otherOptions:
            [
                new Option("Filotimo"),
                new Option("Andreia"),
                new Option("Xenia")
            ],
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Easy,
            content: "Which three‑stringed bowed instrument is central to Cretan folk music?",
            correctOption: new Option("Lyra"),
            otherOptions:
            [
                new Option("Violin"),
                new Option("Laouto"),
                new Option("Santouri")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Easy,
            content: "What clear grape‑based spirit is traditionally offered before and after meals in Crete?",
            correctOption: new Option("Raki"),
            otherOptions:
            [
                new Option("Ouzo"),
                new Option("Tsipouro"),
                new Option("Mastiha")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Easy,
            content: "Which energetic circle dance, performed at Cretan celebrations, often builds in speed and intensity?",
            correctOption: new Option("Pentozali"),
            otherOptions:
            [
                new Option("Siganos"),
                new Option("Syrtos"),
                new Option("Kalamatianos")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "What are “mantinades” in the context of Cretan music and culture?",
            correctOption: new Option("Improvised couplets sung in poetic duels"),
            otherOptions:
            [
                new Option("Traditional shepherd’s whistles"),
                new Option("Ceremonial dance steps"),
                new Option("Types of olive oil press")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "Which barley rusk‑based dish topped with tomato, cheese, and oregano is a Cretan specialty?",
            correctOption: new Option("Dákos"),
            otherOptions:
            [
                new Option("Kalitsounia"),
                new Option("Sfakianes pites"),
                new Option("Antikristo")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "Which celebration in Crete often draws larger crowds than birthday parties and honors one’s patron saint?",
            correctOption: new Option("Name Day"),
            otherOptions:
            [
                new Option("Harvest Festival"),
                new Option("Wedding Feast"),
                new Option("Easter Vigil")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "What festive event involves roasting a whole lamb over an open fire on Crete?",
            correctOption: new Option("Easter Sunday Feast"),
            otherOptions:
            [
                new Option("Name Day Celebration"),
                new Option("Simonopetra Feast"),
                new Option("Wine Festival")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Hard,
            content: "What is “filotimo,” a core Cretan value often cited alongside hospitality?",
            correctOption: new Option("A sense of honor, duty, and pride"),
            otherOptions:
            [
                new Option("A ritual dance step"),
                new Option("A type of folk song"),
                new Option("A traditional sweet pastry")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Hard,
            content: "Which poetic‑musical practice on Crete involves exchanging improvised verses to showcase wit and emotion?",
            correctOption: new Option("Mantinades"),
            otherOptions:
            [
                new Option("Kantada"),
                new Option("Epigrapha"),
                new Option("Eroskritos")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Hard,
            content: "Which traditional men’s garment includes black woolen trousers and a fringed headscarf called a “sariki”?",
            correctOption: new Option("Vraka attire"),
            otherOptions:
            [
                new Option("Fustanella costume"),
                new Option("Tsarouchi uniform"),
                new Option("Pilav dressing")
            ],
            
            type: QuestionType.Regular
        );

        // Skippable questions start here
        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "What are “kalitsounia” commonly filled with in Crete?",
            correctOption: new Option("Cheese or wild greens"),
            otherOptions:
            [
                new Option("Figs and nuts"),
                new Option("Honey and sesame"),
                new Option("Lamb and onions")
            ],
            
            type: QuestionType.Skippable
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "Which annual event in Rethymno celebrates the island’s Venetian heritage with music and theater?",
            correctOption: new Option("Renaissance Festival"),
            otherOptions:
            [
                new Option("Archanes Wine Festival"),
                new Option("Apokries Carnival"),
                new Option("Saint Titus Feast")
            ],
            
            type: QuestionType.Skippable
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Easy,
            content: "Which Cretan dish involves slow‑roasting lamb ribs?",
            correctOption: new Option("Antikristo"),
            otherOptions:
            [
                new Option("Stifado"),
                new Option("Moussaka"),
                new Option("Pastitsio")
            ],
            
            type: QuestionType.Skippable
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Hard,
            content: "Which Cretan festival highlights centuries‑old winemaking traditions?",
            correctOption: new Option("Wine Festival of Archanes"),
            otherOptions:
            [
                new Option("Olive Harvest Feast"),
                new Option("Harvest of Heraklion"),
                new Option("Festival of the Olive Tree")
            ],
            
            type: QuestionType.Skippable
        );
    }

    public static IEnumerable<Question> ForExam()
    {
        // 12 exam questions: 4 Easy, 4 Medium, 4 Hard

        // 4 Easy
        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Easy,
            content: "What term describes the traditional Cretan value of generous hospitality to guests?",
            correctOption: new Option("Philoxenia"),
            otherOptions:
            [
                new Option("Filotimo"),
                new Option("Andreia"),
                new Option("Xenia")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Easy,
            content: "Which three‑stringed bowed instrument is central to Cretan folk music?",
            correctOption: new Option("Lyra"),
            otherOptions:
            [
                new Option("Violin"),
                new Option("Laouto"),
                new Option("Santouri")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Easy,
            content: "What clear grape‑based spirit is traditionally offered before and after meals in Crete?",
            correctOption: new Option("Raki"),
            otherOptions:
            [
                new Option("Ouzo"),
                new Option("Tsipouro"),
                new Option("Mastiha")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Easy,
            content: "Which energetic circle dance, performed at Cretan celebrations, often builds in speed and intensity?",
            correctOption: new Option("Pentozali"),
            otherOptions:
            [
                new Option("Siganos"),
                new Option("Syrtos"),
                new Option("Kalamatianos")
            ],
            
            type: QuestionType.Regular
        );

        // 4 Medium
        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "What are “mantinades” in the context of Cretan music and culture?",
            correctOption: new Option("Improvised couplets sung in poetic duels"),
            otherOptions:
            [
                new Option("Traditional shepherd’s whistles"),
                new Option("Ceremonial dance steps"),
                new Option("Types of olive oil press")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "Which barley rusk‑based dish topped with tomato, cheese, and oregano is a Cretan specialty?",
            correctOption: new Option("Dákos"),
            otherOptions:
            [
                new Option("Kalitsounia"),
                new Option("Sfakianes pites"),
                new Option("Antikristo")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "Which celebration in Crete often draws larger crowds than birthday parties and honors one’s patron saint?",
            correctOption: new Option("Name Day"),
            otherOptions:
            [
                new Option("Harvest Festival"),
                new Option("Wedding Feast"),
                new Option("Easter Vigil")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Medium,
            content: "Which annual event in Rethymno celebrates the island’s Venetian heritage with music and theater?",
            correctOption: new Option("Renaissance Festival of Rethymno"),
            otherOptions:
            [
                new Option("Archanes Wine Festival"),
                new Option("Apokries Carnival"),
                new Option("Saint Titus Feast")
            ],
            
            type: QuestionType.Regular
        );

        // 4 Hard
        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Hard,
            content: "What is “filotimo,” a core Cretan value often cited alongside hospitality?",
            correctOption: new Option("A sense of honor, duty, and pride"),
            otherOptions:
            [
                new Option("A ritual dance step"),
                new Option("A type of folk song"),
                new Option("A traditional sweet pastry")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Hard,
            content: "Which Cretan festival in Archanes highlights centuries‑old winemaking traditions?",
            correctOption: new Option("Wine Festival of Archanes"),
            otherOptions:
            [
                new Option("Olive Harvest Feast"),
                new Option("Harvest of Heraklion"),
                new Option("Festival of the Olive Tree")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Hard,
            content: "Which traditional men’s garment includes black woolen trousers and a fringed headscarf called a “sariki”?",
            correctOption: new Option("Vraka and Sariki attire"),
            otherOptions:
            [
                new Option("Fustanella costume"),
                new Option("Tsarouchi uniform"),
                new Option("Pilav dressing")
            ],
            
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.Culture,
            difficulty: Difficulty.Hard,
            content: "What poetic‑musical practice on Crete involves exchanging improvised verses to showcase wit and emotion?",
            correctOption: new Option("Mantinades"),
            otherOptions:
            [
                new Option("Kantada"),
                new Option("Epigrapha"),
                new Option("Eroskritos")
            ],
            
            type: QuestionType.Regular
        );
    }
}
