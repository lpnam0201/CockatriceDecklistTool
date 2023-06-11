using CockatriceDeckListTool.Common;
using CockatriceDeckListTool.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CockatriceDeckListTool.Process
{
    public class DeckDiffProcess
    {
        public void Execute(string deck1, string deck2)
        {
            var config = new ConfigReader().GetConfig();
            var allDeckPaths = Directory.GetFiles(config.DeckDirectory);

            var deck1Path = GetDeckPath(allDeckPaths, deck1);
            var deck2Path = GetDeckPath(allDeckPaths, deck2);

            var deckReader = new DeckReader();
            var cockatriceDeck1 = deckReader.Read(deck1Path);
            var cockatriceDeck2 = deckReader.Read(deck2Path);

            CompareDecks(cockatriceDeck1, cockatriceDeck2);
        }

        private string GetDeckPath(string[] allDeckPaths, string deckName)
        {
            return allDeckPaths.First(x => Path.GetFileNameWithoutExtension(x) == deckName);
        }

        private void CompareDecks(CockatriceDeck cockatriceDeck1, CockatriceDeck cockatriceDeck2)
        {
            var main1 = cockatriceDeck1.GetMainZone();
            var main2 = cockatriceDeck2.GetMainZone();

            foreach (var card1 in main1.Card)
            {
                var card2 = main2.Card.FirstOrDefault(x => x.Name == card1.Name);
                if (card2 != null)
                {
                    Console.WriteLine($"" +
                        $"{OutputCardName(card1.Name)}({card1.Number}) " +
                        $" - " +
                        $"{OutputCardName(card2.Name)}({card2.Number})");
                }
            }
        }

        private string OutputCardName(string cardName)
        {
            return string.Format("{0, 40}", cardName);
        }
    }
}
