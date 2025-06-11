using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data.Questions;

internal static class HistoryQuestions
{
    public static IEnumerable<Question> ForQuiz()
    {
        // 15 questions for the quiz (numbers 1–15)
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

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Hard,
            content: "During which period did Crete come under the control of Arab forces, establishing the Emirate of Crete?",
            correctOption: new Option("824–961 CE"),
            otherOptions:
            [
                new Option("67 BCE–330 CE"),
                new Option("1204–1669"),
                new Option("961–1204")
            ],
            number: 2,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Easy,
            content: "What is the name of the famous Minoan palace complex near Heraklion?",
            correctOption: new Option("Knossos"),
            otherOptions:
            [
                new Option("Delphi"),
                new Option("Gortyn"),
                new Option("Mycenae")
            ],
            number: 3,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which script, used by the Mycenaeans on Crete, was an adaptation of the Minoan Linear A?",
            correctOption: new Option("Linear B"),
            otherOptions:
            [
                new Option("Phoenician"),
                new Option("Greek Alphabet"),
                new Option("Cuneiform")
            ],
            number: 4,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "What was the main consequence of the Cretan War (1645–1669)?",
            correctOption: new Option("Crete was ceded to the Ottomans by Venice."),
            otherOptions:
            [
                new Option("The Arab Emirate was established."),
                new Option("Crete gained independence."),
                new Option("Crete became a Roman province.")
            ],
            number: 5,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Hard,
            content: "What was the name of the semi-autonomous government established on Crete in 1898?",
            correctOption: new Option("The Cretan State"),
            otherOptions:
            [
                new Option("The Kingdom of Candia"),
                new Option("The Cretan Republic"),
                new Option("The Hellenic Dominion")
            ],
            number: 6,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Easy,
            content: "In what year did Crete officially unite with the Kingdom of Greece?",
            correctOption: new Option("1913"),
            otherOptions:
            [
                new Option("1821"),
                new Option("1898"),
                new Option("1941")
            ],
            number: 7,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which ancient Cretan city became a prominent Roman capital and is known for its legal code?",
            correctOption: new Option("Gortyn"),
            otherOptions:
            [
                new Option("Knossos"),
                new Option("Phaistos"),
                new Option("Chania")
            ],
            number: 8,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Hard,
            content: "Which general led the Byzantine reconquest of Crete in 961 CE?",
            correctOption: new Option("Nicephorus Phocas"),
            otherOptions:
            [
                new Option("Flavius Belisarius"),
                new Option("Theodosius the Great"),
                new Option("Basil II")
            ],
            number: 9,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "What was a key characteristic of Venetian rule on Crete?",
            correctOption: new Option("Construction of fortified cities and Renaissance architecture"),
            otherOptions:
            [
                new Option("Conversion of the population to Islam"),
                new Option("Complete cultural isolation from Europe"),
                new Option("Decline of trade and maritime activity")
            ],
            number: 10,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which German military operation led to the capture of Crete during World War II?",
            correctOption: new Option("Operation Mercury"),
            otherOptions:
            [
                new Option("Operation Barbarossa"),
                new Option("Operation Overlord"),
                new Option("Operation Torch")
            ],
            number: 11,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Easy,
            content: "In what year did the Battle of Crete take place?",
            correctOption: new Option("1941"),
            otherOptions:
            [
                new Option("1939"),
                new Option("1943"),
                new Option("1945")
            ],
            number: 12,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which group of local fighters resisted the German occupation of Crete during WWII?",
            correctOption: new Option("The Cretan Resistance"),
            otherOptions:
            [
                new Option("The Aegean Militia"),
                new Option("The Hellenic Legion"),
                new Option("The Cretan Guard")
            ],
            number: 13,
            type: QuestionType.Skippable
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Hard,
            content: "Which educational institution was established in Crete in 1973 and contributed to post-war development?",
            correctOption: new Option("The University of Crete"),
            otherOptions:
            [
                new Option("Technical University of Athens"),
                new Option("Ionian Academy"),
                new Option("University of Thessaloniki")
            ],
            number: 14,
            type: QuestionType.Skippable
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which ancient site on Crete is associated with the earliest known legal code in Greece?",
            correctOption: new Option("Gortyn"),
            otherOptions:
            [
                new Option("Knossos"),
                new Option("Phaistos"),
                new Option("Zakros")
            ],
            number: 15,
            type: QuestionType.Skippable
        );
    }

    public static IEnumerable<Question> ForExam()
    {
        // 12 exam questions: 4 Easy, 4 Medium, 4 Hard

        // 4 Easy
        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Easy,
            content: "What is the name of the famous Minoan palace complex near Heraklion?",
            correctOption: new Option("Knossos"),
            otherOptions:
            [
                new Option("Delphi"),
                new Option("Gortyn"),
                new Option("Mycenae")
            ],
            number: 1,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Easy,
            content: "In what year did Crete officially unite with the Kingdom of Greece?",
            correctOption: new Option("1913"),
            otherOptions:
            [
                new Option("1821"),
                new Option("1898"),
                new Option("1941")
            ],
            number: 2,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Easy,
            content: "In what year did the Battle of Crete take place?",
            correctOption: new Option("1941"),
            otherOptions:
            [
                new Option("1939"),
                new Option("1943"),
                new Option("1945")
            ],
            number: 3,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Easy,
            content: "Which empire controlled Crete immediately before the Ottomans?",
            correctOption: new Option("The Republic of Venice"),
            otherOptions:
            [
                new Option("The Roman Empire"),
                new Option("The Byzantine Empire"),
                new Option("The Arab Emirate")
            ],
            number: 4,
            type: QuestionType.Regular
        );

        // 4 Medium
        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which script, used by the Mycenaeans on Crete, was an adaptation of the Minoan Linear A?",
            correctOption: new Option("Linear B"),
            otherOptions:
            [
                new Option("Phoenician"),
                new Option("Greek Alphabet"),
                new Option("Cuneiform")
            ],
            number: 5,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which ancient Cretan city became a prominent Roman capital and is known for its legal code?",
            correctOption: new Option("Gortyn"),
            otherOptions:
            [
                new Option("Knossos"),
                new Option("Phaistos"),
                new Option("Chania")
            ],
            number: 6,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which German military operation led to the capture of Crete during World War II?",
            correctOption: new Option("Operation Mercury"),
            otherOptions:
            [
                new Option("Operation Barbarossa"),
                new Option("Operation Overlord"),
                new Option("Operation Torch")
            ],
            number: 7,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Medium,
            content: "Which group of local fighters resisted the German occupation of Crete during WWII?",
            correctOption: new Option("The Cretan Resistance"),
            otherOptions:
            [
                new Option("The Aegean Militia"),
                new Option("The Hellenic Legion"),
                new Option("The Cretan Guard")
            ],
            number: 8,
            type: QuestionType.Regular
        );

        // 4 Hard
        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Hard,
            content: "During which period did Crete come under the control of Arab forces, establishing the Emirate of Crete?",
            correctOption: new Option("824–961 CE"),
            otherOptions:
            [
                new Option("67 BCE–330 CE"),
                new Option("1204–1669"),
                new Option("961–1204")
            ],
            number: 9,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Hard,
            content: "Which general led the Byzantine reconquest of Crete in 961 CE?",
            correctOption: new Option("Nicephorus Phocas"),
            otherOptions:
            [
                new Option("Flavius Belisarius"),
                new Option("Theodosius the Great"),
                new Option("Basil II")
            ],
            number: 10,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Hard,
            content: "Which educational institution was established in Crete in 1973 and contributed to post-war development?",
            correctOption: new Option("The University of Crete"),
            otherOptions:
            [
                new Option("Technical University of Athens"),
                new Option("Ionian Academy"),
                new Option("University of Thessaloniki")
            ],
            number: 11,
            type: QuestionType.Regular
        );

        yield return new Question(
            topic: Topics.History,
            difficulty: Difficulty.Hard,
            content: "What long-term cultural impact did the Ottoman occupation have on Cretan architecture?",
            correctOption: new Option("Integration of minarets and domed mosques into cityscapes"),
            otherOptions:
            [
                new Option("Use of Roman columns in all buildings"),
                new Option("Ban on all religious buildings"),
                new Option("Construction of Gothic cathedrals")
            ],
            number: 12,
            type: QuestionType.Regular
        );
    }
}
