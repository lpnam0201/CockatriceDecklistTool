using CockatriceDeckListTool.Common;
using CockatriceDeckListTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CockatriceDeckListTool.Process
{
    public class CardUsageCountProcess
    {
        public void Execute()
        {
            var cockatriceDecks = new DeckReader().GetDecksInPlay();
            var cardCountDictionary = GetCardCount(cockatriceDecks);
            new OutputWriter().WriteResult(cardCountDictionary);
        }

        private Dictionary<string, int> GetCardCount(List<CockatriceDeck> cockatriceDecks)
        {
            var dict = new Dictionary<string, int>();

            foreach (var cockatriceDeck in cockatriceDecks)
            {
                var main = cockatriceDeck.GetMainZone();
                foreach (var card in main.Card)
                {
                    var name = card.Name;
                    var count = card.Number;

                    if (dict.ContainsKey(name))
                    {
                        var currentCount = dict[name];
                        dict[name] = currentCount + count;
                    }
                    else
                    {
                        dict[name] = count;
                    }
                }
            }

            return dict;
        }
    }
}
