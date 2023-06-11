using CockatriceDeckListTool.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CockatriceDeckListTool.Common
{
    public class ConfigReader
    {
        public Config GetConfig()
        {
            var configs = File.ReadAllLines("config.txt");
            var deckDirectory = configs[0];
            var decksInPlay = File.ReadAllLines(configs[1]);

            return new Config
            {
                DeckDirectory = deckDirectory,
                DecksInPlay = decksInPlay
            };
        }
    }
}
