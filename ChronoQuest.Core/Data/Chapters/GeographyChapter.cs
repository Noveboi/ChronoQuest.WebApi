using ChronoQuest.Core.Data.Questions;
using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data.Chapters;

internal static class GeographyChapter
{
    public static readonly Chapter Chapter = new Chapter(
            order: 2,
            topic: Topics.Geography,
            title: "Geography",
            content: """
                     <article>
                       <h3>1.1 Location and Size</h3>
                       <p>
                         Crete, the jewel of the Mediterranean, stands as the largest island in Greece and ranks as the fifth‑largest island in the entire Mediterranean Sea. Stretching approximately 260 km from its westernmost point near Chania to its eastern tip at Sitia, Crete spans a width that fluctuates between a narrow 12 km at its slimmest in the Selinous Gulf and over 60 km in its broadest central regions.  Positioned strategically at the crossroads of Europe, Asia, and Africa, Crete has long served as a maritime bridge, shaping trade, culture, and geopolitics.
                       </p>
                     </article>
                   
                     <article>
                       <h3>1.2 Topography and Landforms</h3>
                       <p>
                         The topography of Crete is strikingly diverse, defined by dramatic mountain ranges, fertile plains, and deep gorges carved by millennia of geological activity:
                       </p>
                       <ul>
                         <li><strong>White Mountains (Lefká Óri):</strong> Located in western Crete, this massif reaches its pinnacle at Mount Pachnes (2,453 m). The region is characterized by steep limestone slopes, plateaus dotted with ancient oak and plane trees, and snowfields that can linger into late spring.</li>
                         <li><strong>Psilorítis (Ida) Range:</strong> Central Crete’s spine, dominated by Mount Ida (Psilorítis) at 2,456 m, the highest peak on the island. Carved by time into rounded summits, it hosts the Idaean Cave, fabled birthplace of Zeus in Greek mythology.</li>
                         <li><strong>Dikti Mountains:</strong> Rising in the east to peaks such as Spathi (2,148 m), these mountains cradle the Lasíthi Plateau, an expansive highland renowned for its windmills and fertile soils.</li>
                         <li><strong>Gorges:</strong> Nature’s artistry is evident in the island’s 4,500+ gorges, including the famed Samariá Gorge, a 16 km canyon that plunges from the Plateau of Omalós to the Libyan Sea, and the steep Imbros Gorge, offering a gentler route through ever-changing landscapes.</li>
                         <li><strong>Coastal Plains:</strong> Flanked by mountain foothills, the plains around Chania, Rethymno, Heraklion, and Sitia are verdant agricultural heartlands, producing olives, grapes, citrus fruits, and vegetables that thrive in the rich alluvial soils.</li>
                       </ul>
                     </article>
                   
                     <article>
                       <h3>1.3 Climate and Weather Patterns</h3>
                       <p>
                         Crete experiences a classic Mediterranean climate, shaped by its latitude and maritime surroundings. This climate fosters a rhythm of leisure and agricultural productivity:
                       </p>
                       <ul>
                         <li><strong>Summers (June–September):</strong> Long, sun-drenched days see daytime highs averaging between 28–32 °C along the coast, often tempered by cooling sea breezes. Inland valleys can reach 35 °C, while mountain summits remain pleasantly cooler.</li>
                         <li><strong>Winters (December–February):</strong> Mild near the sea, with temperatures seldom dropping below 10 °C, yet the mountains brim with rainfall and occasional snow over 1,200 m, transforming peaks into seasonal wonderlands.</li>
                         <li><strong>Rainfall:</strong> Annual precipitation varies from roughly 600 mm in western regions to under 400 mm in the drier east, concentrated in short, intense winter storms. Spring and autumn are transitional periods offering the best balance of mild temperatures and greenery.</li>
                         <li><strong>Microclimates:</strong> The contrast between coastal humidity, mountain coolness, and inland heat creates microclimates where unique flora and fauna evolve, enriching the island’s biodiversity.</li>
                       </ul>
                     </article>
                   
                     <article>
                       <h3>1.4 Flora and Fauna</h3>
                       <p>
                         Crete’s ecological tapestry is as varied as its terrain, harboring species found nowhere else on Earth:
                       </p>
                       <ul>
                         <li><strong>Vegetation Zones:</strong> From aromatic maquis shrublands of thyme, oregano, and sage along the coastline to dense olive groves and cypress forests on lower slopes, rising to alpine grasslands and endemic flowering plants like Campanula cretica above 1,500 m.</li>
                         <li><strong>Endemic Wildlife:</strong> The shy Cretan wild goat, known locally as kri‑kri, roams the mountainous gorges, while small mammals like the Cretan spiny mouse and the Cretan shrew thrive in rocky habitats.</li>
                         <li><strong>Avian Diversity:</strong> Raptors such as the bearded vulture and Bonelli’s eagle soar overhead, while migratory birds use the island as a crucial stopover between Europe and Africa.</li>
                         <li><strong>Marine Ecosystems:</strong> Coastal waters host seagrass meadows of Posidonia oceanica, vital for carbon sequestration and as nurseries for fish. Loggerhead sea turtles (Caretta caretta) nest on sandy beaches like Matala and Rethymno.</li>
                       </ul>
                     </article>
                   
                     <article>
                       <h3>1.5 Coastline, Beaches, and Marine Features</h3>
                       <p>
                         Crete’s varied coastline, stretching over 1,000 km, offers an array of coastal landscapes:
                       </p>
                       <ul>
                         <li><strong>Sandy Shores:</strong> Expansive beaches like Elafonisi, famous for its pink-hued sands and shallow lagoons, and Falassarna, renowned for crystalline waters and sweeping sunsets.</li>
                         <li><strong>Secluded Coves:</strong> Hidden gems such as Balos Lagoon, accessible by boat or rugged track, and Seitan Limania, a dramatic inlet framed by limestone cliffs.</li>
                         <li><strong>Rock Formations and Caves:</strong> The Diktaean Cave on Mount Dikti, steeped in myth, and rugged sea caves along the south coast, offering sheltered snorkel spots and glimpses into Crete’s geological history.</li>
                       </ul>
                     </article>
                     """,
            questions: GeographyQuestions.ForQuiz().ToList());
}