using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data.Review;

public static class HistoryReviewParagraphs
{
    public static IEnumerable<ReviewMaterialParagraph> All()
    {
        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.History,
            Order = 1,
            Content = "Crete's strategic location in the eastern Mediterranean made it a cradle of European civilization. The island was home to the Minoan civilization, which flourished between 3000 BCE and 1450 BCE. Known for its advanced architecture, art, and maritime trade, the Minoans built complex palace structures like the one at Knossos and developed one of the earliest writing systems in Europe—Linear A. Their influence extended to the Aegean and beyond, forming the cultural bedrock of ancient Greece."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.History,
            Order = 2,
            Content = "Around 1450 BCE, the Minoan civilization began to decline, possibly due to a combination of natural disasters (such as the volcanic eruption on Thera) and invasions from the Mycenaeans, a mainland Greek people who adopted many Minoan customs. The Mycenaean presence marked the transition from the Bronze Age to the early Greek world, eventually leading into the so-called Greek Dark Ages. Despite this, Minoan influence persisted in mythology and Greek religious practices."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.History,
            Order = 3,
            Content = "After the Mycenaean era, Crete became part of various empires and dominions. It was absorbed into the Roman Empire in 67 BCE and later integrated into the Byzantine Empire, during which it retained its Christian heritage and developed a rich religious and artistic tradition. Between 824 and 961 CE, Arab forces captured the island and established the Emirate of Crete, turning it into a base for piracy and Islamic culture. The Byzantine reconquest in 961 CE reestablished Christian rule, but the island remained a contested frontier."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.History,
            Order = 4,
            Content = "In 1204, following the Fourth Crusade, Crete was sold to the Republic of Venice. This ushered in over four centuries of Venetian rule, during which the island developed a unique fusion of Orthodox Greek and Western European (mostly Catholic and Italian) cultural traits. Venetian architecture, administrative systems, and economic structures left a lasting imprint, especially in cities like Heraklion, Rethymno, and Chania. Despite occasional uprisings, Venetian Crete experienced a relative cultural flourishing, including the Cretan Renaissance in art and literature."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.History,
            Order = 5,
            Content = "In 1669, the Ottoman Empire took control after a prolonged siege of Candia (Heraklion). Under Ottoman rule, the population was divided between Christian Greeks and ruling Muslim Turks, leading to frequent unrest. Cretan uprisings in the 19th century were part of a broader Greek national movement, and by 1898, Crete achieved autonomy under international oversight. In 1913, it officially united with the modern Greek state. The 20th century saw Crete play a strategic role during World War II, particularly in the Battle of Crete, where German paratroopers faced fierce resistance from both Allied forces and local civilians."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.History,
            Order = 6,
            Content = "Understanding the long and turbulent history of Crete provides deeper insight into the island’s modern identity. Each era—Minoan, Roman, Byzantine, Arab, Venetian, Ottoman, and modern Greek—has left its mark on the cultural and political fabric of the island. This historical layering is reflected in everything from Crete's architecture and cuisine to its dialects and local traditions. Reviewing these historical developments helps students connect key facts with broader themes of resilience, cultural synthesis, and Mediterranean geopolitics."
        };
    }
}