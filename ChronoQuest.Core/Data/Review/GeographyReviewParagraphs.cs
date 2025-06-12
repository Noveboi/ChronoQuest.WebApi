using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data.Review;

public static class GeographyReviewParagraphs
{
    public static IEnumerable<ReviewMaterialParagraph> All()
    {
        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Geography,
            Order = 1,
            Content = "Crete’s geographical significance stems from its position at the crossroads of Europe, Asia, and Africa. As the largest island in Greece, it spans over 260 km in length and boasts a dramatic and varied landscape. Its strategic location made it a natural hub for maritime trade and cultural exchange throughout antiquity, influencing not just Greek civilization but the wider Mediterranean basin."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Geography,
            Order = 2,
            Content = "The island’s topography is defined by three major mountain ranges: the White Mountains in the west, Psiloritis (Ida) in the center, and the Dikti range in the east. These mountains shape the island's microclimates and serve as natural barriers that historically fostered distinct local communities. Gorges like Samariá and Imbros carve through the terrain, offering breathtaking views and ecological diversity."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Geography,
            Order = 3,
            Content = "Crete’s climate is predominantly Mediterranean, with hot, dry summers and mild, wetter winters. The combination of mountainous terrain and surrounding seas results in numerous microclimates. Coastal areas enjoy more temperate weather, while higher elevations receive snow during winter months. This variety enables a wide range of agricultural products to flourish year-round."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Geography,
            Order = 4,
            Content = "The island’s flora and fauna reflect its isolation and unique environmental conditions. Over 2,000 plant species are found on Crete, many of which are endemic, such as the Cretan ebony and dittany. The kri-kri (Cretan wild goat), endangered and protected, roams mountainous areas. Marine ecosystems include seagrass beds vital for biodiversity, and the coasts host nesting grounds for endangered loggerhead turtles."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Geography,
            Order = 5,
            Content = "Crete’s extensive coastline, stretching over 1,000 km, offers a spectrum of beaches—from the pink sands of Elafonisi to the rugged cliffs of Seitan Limania. Its marine features are both scenic and ecologically important. Coastal plains serve as vital agricultural zones, producing olives, citrus fruits, and grapes. This interplay between natural beauty and utility exemplifies the deep interconnection between geography and daily life in Crete."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Geography,
            Order = 6,
            Content = "A solid understanding of Crete’s geography is essential for appreciating its history and culture. The island’s physical environment has not only shaped human settlement and economy but also contributed to Crete’s resilience and distinctiveness. Mountains provided refuge during invasions, while fertile plains ensured agricultural sustainability through the centuries."
        };
    }
}