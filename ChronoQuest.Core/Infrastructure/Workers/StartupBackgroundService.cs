using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ChronoQuest.Core.Infrastructure.Workers;

internal sealed class StartupBackgroundService(IServiceProvider sp) : BackgroundService
{
    private readonly Topic _geography = new("Geography");
    private readonly Topic _history = new("History");
    private readonly Topic _culture = new("Culture");
    
    private readonly ILogger _log = Log.ForContext<StartupBackgroundService>();
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = sp.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ChronoQuestContext>();

        var pending = await context.Database.GetPendingMigrationsAsync(stoppingToken);
        foreach (var migration in pending)
        {
            _log.Information("Migrating to {migration}", migration);
            await context.Database.MigrateAsync(migration, stoppingToken);
        }
        
        if (await context.Chapters.AnyAsync(stoppingToken))
        {
            _log.Information("Database is seeded.");
            return;
        }
        
        _log.Information("Seeding database with data...");
        context.Topics.AddRange(GetTopics());
        context.Chapters.AddRange(GetChapters());
        
        await context.SaveChangesAsync(stoppingToken);
        _log.Information("Finished seeding.");
    }

    private IEnumerable<Topic> GetTopics() => [_geography, _history, _culture];

    private IEnumerable<Chapter> GetChapters()
    {
        yield return new Chapter(
            order: 2,
            topic: _geography,
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
            questions: []);
        
        yield return new Chapter(
            order: 1,
            topic: _history,
            title: "History",
            content: """
                     <article>
                       <h3>2.1 Minoan Civilization (c. 2700–1450 BCE)</h3>
                       <p>
                         The Minoan Civilization marks the dawn of Crete’s recorded history and represents Europe’s first major advanced society. Flourishing during the Bronze Age, the Minoans built sophisticated urban centers centered around massive palatial complexes such as Knossos, Phaistos, Malia, and Zakros. These palaces were not just royal residences, but administrative, religious, and economic hubs that governed extensive territories. Minoan architecture was marked by multi-storied buildings, vibrant frescoes, open courtyards, and advanced engineering, including complex drainage and plumbing systems that remain impressive today.
                       </p>
                       <p>
                         The Minoans developed extensive trade networks with Egypt, Anatolia, the Levant, and the Cyclades, exporting pottery, olive oil, and saffron in exchange for copper, tin, and luxury goods. Their undeciphered script, known as Linear A, along with their art, religion (featuring goddesses, bulls, and double axes), and seafaring prowess, show a society steeped in ritual, creativity, and innovation. The eruption of Thera (modern-day Santorini) and subsequent environmental upheaval, combined with Mycenaean invasions from mainland Greece, likely contributed to the civilization’s decline around 1450 BCE.
                       </p>
                     </article>
                   
                     <article>
                       <h3>2.2 Mycenaean Influence and the Greek Dark Ages (c. 1450–1100 BCE)</h3>
                       <p>
                         After the fall of the Minoan centers, the Mycenaeans—Greek-speaking warriors from the mainland—established control over Crete, bringing with them new customs, burial practices, and the Linear B script, which was used for administrative purposes. They preserved much of the Minoan infrastructure but infused it with their militaristic and hierarchical culture. Despite continued regional significance, the Mycenaean presence in Crete was comparatively short-lived.
                       </p>
                       <p>
                         Around 1100 BCE, widespread destruction across the Eastern Mediterranean led to the collapse of palatial societies and the beginning of the so-called Greek Dark Ages. In Crete, urban centers shrank, monumental building ceased, literacy disappeared, and long-distance trade withered. The island reverted to a more rural, kinship-based society, yet traditions and myths endured, eventually to be reshaped during Greece’s revival centuries later.
                       </p>
                     </article>
                   
                     <article>
                       <h3>2.3 Archaic and Classical Periods (c. 800–67 BCE)</h3>
                       <p>
                         Emerging from the Dark Ages, Crete developed into a patchwork of independent city-states or poleis, such as Gortyn, Knossos, and Lyttos. These cities cultivated their own laws, armies, and alliances. Gortyn, for example, produced one of the oldest and most complete examples of Greek law, inscribed on a massive stone wall in the 5th century BCE. While mainland Greece saw the flourishing of democracy, philosophy, and art in cities like Athens, Crete remained somewhat isolated, preserving aristocratic rule and older social customs.
                       </p>
                       <p>
                         Despite limited political unity, Crete was deeply involved in Mediterranean trade, colonization efforts, and warfare. Its warriors and archers were sought after as mercenaries, and its cities participated in broader Greek religious festivals and cultural traditions. During the Classical era, Crete often aligned itself with larger powers such as Sparta or Macedonia, though internal rivalries frequently hindered island-wide cooperation.
                       </p>
                     </article>
                   
                     <article>
                       <h3>2.4 Roman and Early Christian Period (67 BCE–330 CE)</h3>
                       <p>
                         In 67 BCE, after a series of military campaigns against piracy, Rome annexed Crete along with Cyrenaica (modern Libya), forming the province of Creta et Cyrenaica. Roman administration brought stability, economic revival, and monumental construction to the island. Cities such as Gortyn, which became the provincial capital, flourished with Roman baths, amphitheaters, temples, and aqueducts. Roman citizenship, language, and customs gradually permeated Cretan society.
                       </p>
                       <p>
                         Christianity began to spread across the island during the 1st century CE. According to tradition, the Apostle Paul appointed Titus, his disciple, as the first bishop of Crete. Early Christian basilicas with intricate mosaics began to dot the landscape, especially in rural areas. By the 4th century, Christianity had largely supplanted older pagan religions, setting the stage for Crete's role within the Christianized Byzantine world.
                       </p>
                     </article>
                   
                     <article>
                       <h3>2.5 Byzantine and Arab Periods (330–961 CE)</h3>
                       <p>
                         After the division of the Roman Empire, Crete became part of the Eastern Roman or Byzantine Empire. While Byzantine rule saw continued Christianization and ecclesiastical development, the island also suffered from pirate raids and instability. In 824 CE, Arab Muslim forces from Andalusia seized Crete and established the Emirate of Crete, with its capital at Chandax (modern Heraklion). This new polity transformed the island into a powerful base for piracy, threatening Byzantine shipping and coastal communities throughout the Aegean.
                       </p>
                       <p>
                         For over a century, the Byzantines attempted to retake Crete. Their efforts culminated in 961 CE when General Nikephoros Phokas launched a massive expedition that reconquered the island. The Byzantines reimposed Christian rule, fortified coastal cities, and built monasteries and churches to reassert their cultural and religious dominance. Despite renewed imperial control, the Arab legacy remained in place names, agricultural practices, and hybridized architecture.
                       </p>
                     </article>
                   
                     <article>
                       <h3>2.6 Venetian Rule (1204–1669)</h3>
                       <p>
                         Following the Fourth Crusade and the fragmentation of the Byzantine Empire, Venice took control of Crete in 1204, officially establishing it as the "Kingdom of Candia." Venetian rule lasted over four centuries and left a profound legacy on Cretan architecture, language, law, and art. Fortified cities like Candia (Heraklion), Rethymno, and Chania were embellished with imposing walls, arsenals, fountains, and loggias that mirrored Venetian Renaissance style.
                       </p>
                       <p>
                         The period also witnessed a remarkable cultural synthesis, giving rise to the Cretan Renaissance. This golden age of letters and visual arts produced luminaries like the painter Domenikos Theotokopoulos (El Greco) and dramatists such as Vitsentzos Kornaros, author of the epic romantic poem *Erotokritos*. However, Venetian control was also marked by heavy taxation, social stratification, and recurring revolts, including the lengthy Cretan War (1645–1669), during which the Ottomans gradually besieged and conquered the island.
                       </p>
                     </article>
                   
                     <article>
                       <h3>2.7 Ottoman Period (1669–1898)</h3>
                       <p>
                         The Ottoman Empire completed its conquest of Crete in 1669 after a 21-year siege of Candia, one of the longest in history. Under Ottoman rule, Crete became a multicultural society where Muslims, Christians, and Jews coexisted, albeit under a system that privileged Muslims politically and economically. The Ottomans introduced new architectural elements, including mosques, hammams, and minarets, many of which were converted from or into churches.
                       </p>
                       <p>
                         While the early years were relatively stable, the 19th century saw frequent revolts as Christian Cretans sought greater autonomy and eventual union with Greece. The Greek War of Independence in 1821 inspired several uprisings, which were met with harsh reprisals. As the Ottoman Empire weakened, foreign powers intervened, and by 1898, following international pressure and continued unrest, the island was granted autonomy under the semi-independent Cretan State.
                       </p>
                     </article>
                   
                     <article>
                       <h3>2.8 The Cretan State and Union with Greece (1898–1913)</h3>
                       <p>
                         The establishment of the Cretan State marked a transitional era of modernization and national aspiration. Under the high commissionership of Prince George of Greece and Denmark, the new administration introduced democratic institutions, legal reforms, and public infrastructure. Eleftherios Venizelos, a prominent Cretan politician, emerged as a leading advocate for unification with Greece and would later become one of modern Greece’s most influential statesmen.
                       </p>
                       <p>
                         Despite tensions with the Ottomans and the Great Powers overseeing the island, the drive for Enosis (union with Greece) remained strong. After the Balkan Wars and Greece’s territorial gains, Crete was officially united with the Kingdom of Greece in December 1913. The island’s long and tumultuous journey through ancient, medieval, and modern empires culminated in its permanent integration into the Greek nation-state.
                       </p>
                     </article>
                     """,
            questions: []);
        
        yield return new Chapter(
            order: 3,
            topic: _culture,
            title: "Culture",
            content: """
                     <article>
                       <h3>3.1 Traditions and Daily Life</h3>
                       <p>
                         The cultural heartbeat of Crete lies in its enduring traditions, which have evolved over millennia yet remain deeply ingrained in the island’s contemporary identity. Life in rural villages still follows seasonal rhythms tied to agriculture, shepherding, and religious observances. Hospitality, or “philoxenia,” is a sacred value; guests are treated with exceptional generosity, often offered food, drink, and shelter without hesitation.
                       </p>
                       <p>
                         Traditional gender roles have modernized significantly, yet older customs linger, especially in smaller communities. Family remains the cornerstone of society, often spanning multiple generations under one roof or living within the same village. Weddings and baptisms are lavish, multi-day affairs that serve as both spiritual milestones and communal gatherings, replete with music, dancing, and feasting. Name days (celebrating one’s patron saint) are observed with equal fervor, often more than birthdays.
                       </p>
                     </article>
                   
                     <article>
                       <h3>3.2 Music and Dance</h3>
                       <p>
                         Cretan music is among the most distinct and emblematic in Greece, characterized by its powerful rhythms, stirring melodies, and improvisational style. At its heart is the <em>lyra</em>, a three-stringed bowed instrument held upright on the knee, often accompanied by the <em>laouto</em> (lute) which provides a rhythmic and harmonic foundation. The lyra’s haunting voice can evoke everything from joyful celebration to profound lament.
                       </p>
                       <p>
                         Music is an essential part of social life and is most visible during festivals, weddings, and village feasts. Improvised verses called “<em>mantinades</em>” are exchanged in a kind of poetic duel, showcasing wit, emotion, and storytelling. Cretan dances, such as the fast-paced <em>pentozali</em>, the elegant <em>siganos</em>, and the celebratory <em>syrtos</em>, are performed in circles or lines, often with escalating energy that sweeps participants and spectators alike into a state of collective joy. These musical traditions are passed down orally and through apprenticeship, ensuring their continuity across generations.
                       </p>
                     </article>
                   
                     <article>
                       <h3>3.3 Cuisine and Gastronomy</h3>
                       <p>
                         Cretan cuisine is the culinary embodiment of the island’s landscape and history—simple, hearty, and infused with the flavors of the Mediterranean. The cornerstone of the diet is the abundant use of extra virgin olive oil, often produced from centuries-old trees that dot the island. Meals emphasize freshness and seasonality, with vegetables, legumes, grains, and herbs forming the base of most dishes.
                       </p>
                       <p>
                         Signature foods include <em>dákos</em> (barley rusk topped with chopped tomatoes, mizithra cheese, and oregano), <em>kalitsounia</em> (sweet or savory cheese pies), and <em>antikristo</em> (lamb slow-roasted around an open flame). Wild greens and foraged herbs—<em>horta</em>—are prized, often boiled and served with lemon and olive oil. Cheese holds a central role, especially varieties like <em>graviera</em>, <em>myzithra</em>, and <em>anthotyro</em>. 
                       </p>
                       <p>
                         Raki (also known as tsikoudia), a clear grape-based spirit, is the customary drink of hospitality. Distilled in the autumn after the grape harvest, it is offered in small glasses before and after meals, or simply in greeting. Dining is a leisurely, communal affair, reinforcing bonds and encouraging conversation. The Cretan diet has drawn global attention for its role in promoting longevity and heart health, aligning with the principles of the Mediterranean diet.
                       </p>
                     </article>
                   
                     <article>
                       <h3>3.4 Traditional Clothing</h3>
                       <p>
                         Traditional Cretan attire, though now largely reserved for festivals and ceremonial events, remains a powerful symbol of regional identity and pride. Men traditionally wear black woolen trousers known as <em>vraka</em>, tucked into high leather boots called <em>stivania</em>, a wide belt, and a long-sleeved shirt, often accompanied by a black fringed headscarf known as the <em>sariki</em>, which is sometimes embroidered with symbolic tears to honor ancestors or martyrs.
                       </p>
                       <p>
                         Women’s dress varies by region but often includes colorful skirts, aprons, embroidered blouses, and elaborate headscarves or jewelry. In some areas, layered silk and velvet garments denote both marital status and wealth. These costumes are proudly displayed during local festivals, processions, and cultural performances, serving not only as aesthetic expressions but also as links to historical memory and ancestral lineage.
                       </p>
                     </article>
                   
                     <article>
                       <h3>3.5 Festivals and Celebrations</h3>
                       <p>
                         The Cretan calendar is studded with festivals that combine religious devotion, folk customs, and joyous celebration. Chief among them are the feasts honoring patron saints, such as Saint Titus in Heraklion or Saint George in mountainous villages, which include liturgical services followed by music, dancing, and communal meals. Easter is the most significant religious event, celebrated with a mix of solemnity and exuberance, including candlelit midnight masses, firecrackers, lamb roasting, and traditional hymns.
                       </p>
                       <p>
                         Secular festivals also play a major role in preserving Cretan heritage. The Renaissance Festival of Rethymno revives the island’s Venetian past through theatrical performances, art exhibits, and concerts. The Wine Festival in Archanes celebrates the region’s ancient winemaking traditions with tastings and folk entertainment, while Carnival (Apokries) brings colorful parades and costumed revelry before the Lenten season.
                       </p>
                       <p>
                         These events often blend ancient rituals with Christian beliefs and contemporary elements, illustrating how Cretan culture seamlessly bridges past and present, sacred and celebratory.
                       </p>
                     </article>
                   
                     <article>
                       <h3>3.6 Values and Identity</h3>
                       <p>
                         At the heart of Cretan culture lies a strong sense of identity forged through centuries of resilience, resistance, and self-reliance. Cretans value personal honor (<em>filotimo</em>), bravery (<em>andreia</em>), and loyalty to family and homeland. These values were historically cultivated through struggles against foreign domination—from Venetian to Ottoman to Nazi occupation—and are reflected in heroic tales, oral histories, and everyday behavior.
                       </p>
                       <p>
                         Regional pride is not merely sentimental; it shapes political attitudes, artistic expression, and even interpersonal conduct. Many Cretans identify as simultaneously Greek and distinctly Cretan, celebrating their dialect, customs, and island’s storied past. The mountains, landscapes, and ancestral villages are seen not just as scenery, but as repositories of memory and meaning.
                       </p>
                       <p>
                         This cultural richness, deeply felt and openly expressed, endows Crete with a unique place in both the Greek national imagination and the broader Mediterranean world.
                       </p>
                     </article>
                     """,
            questions: []);
    }
}