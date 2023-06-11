using CockatriceDeckListTool.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CockatriceDeckListTool.Common
{
    public class DeckReader
    {
        public CockatriceDeck Read(string deckPath)
        {
            CockatriceDeck cockatriceDeck;
            using (var stream = File.OpenRead(deckPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CockatriceDeck));
                cockatriceDeck = (CockatriceDeck)xmlSerializer.Deserialize(stream);
            }

            return cockatriceDeck;
        }

        public List<CockatriceDeck> GetDecksInPlay()
        {
            var config = new ConfigReader().GetConfig();

            var allDeckPaths = Directory.GetFiles(config.DeckDirectory);

            var deckReader = new DeckReader();
            var cockatriceDecks = new List<CockatriceDeck>();
            foreach (var deckPath in allDeckPaths)
            {
                if (ShouldReadDeck(config.DecksInPlay, deckPath))
                {
                    var deck = deckReader.Read(deckPath);
                    cockatriceDecks.Add(deck);
                }
            }

            return cockatriceDecks;
        }

        private bool ShouldReadDeck(string[] playedDecks, string deckPath)
        {
            var deckFileName = Path.GetFileNameWithoutExtension(deckPath);

            return playedDecks.Contains(deckFileName, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
