using CockatriceDeckListTool.Common;
using CockatriceDeckListTool.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CockatriceDeckListTool.Process
{
    public class SleeveCountProcess
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
                        var value = dict[name];
                        if (count > value)
                        {
                            dict[name] = count;
                        }
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
