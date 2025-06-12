using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data.Review;

public static class CultureReviewParagraphs
{
    public static IEnumerable<ReviewMaterialParagraph> All()
    {
        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Culture,
            Order = 1,
            Content = "Cretan culture is a vibrant fusion of ancient traditions, regional customs, and historical legacies. Rooted in thousands of years of human settlement, it retains distinctive characteristics that set it apart from mainland Greece. From music and dance to cuisine and festivals, Cretan culture reflects a deep reverence for community, land, and history."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Culture,
            Order = 2,
            Content = "Traditional music is a cornerstone of Cretan cultural identity. Instruments like the lyra and laouto create melodic frameworks for folk songs and dances such as the pentozali and syrtos. These performances are not just entertainment—they are community rituals that often take place during weddings, festivals, and national holidays, preserving oral history and local pride."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Culture,
            Order = 3,
            Content = "Cretan cuisine is renowned for its healthfulness, simplicity, and reliance on fresh, local ingredients. Olive oil, herbs, cheeses, and seasonal vegetables form the basis of daily meals. Dishes like dakos, kalitsounia, and lamb with stamnagathi highlight the island’s agricultural richness and culinary heritage, shaped by centuries of Venetian and Ottoman influence."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Culture,
            Order = 4,
            Content = "Festivals and religious traditions are deeply ingrained in Cretan life. From Easter celebrations to local saints’ feast days, these events blend Orthodox Christian observances with ancient customs. They often feature processions, traditional attire, music, and feasting, reinforcing social bonds and collective identity in both urban and rural communities."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Culture,
            Order = 5,
            Content = "Cretan hospitality, or 'philoxenia', is a time-honored tradition rooted in both necessity and cultural philosophy. Welcoming strangers with generosity is common in villages and cities alike. This attitude, combined with a fierce sense of independence and honor, shapes the Cretan character—resilient, proud, and deeply connected to the island’s heritage."
        };

        yield return new ReviewMaterialParagraph
        {
            Topic = Topics.Culture,
            Order = 6,
            Content = "The legacy of Cretan culture is visible not only in everyday practices but also in literature, visual arts, and local crafts. Iconic figures like Nikos Kazantzakis have immortalized the Cretan spirit in writing, while artisans continue to produce ceramics, embroidery, and woodcraft that preserve ancestral techniques. Cultural continuity, even amid modernization, remains a defining trait of life on the island."
        };
    }
}