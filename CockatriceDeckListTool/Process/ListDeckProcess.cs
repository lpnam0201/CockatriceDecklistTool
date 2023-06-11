using CockatriceDeckListTool.Common;
using System;
using System.IO;

namespace CockatriceDeckListTool.Process
{
    public class ListDeckProcess
    {
        public void Execute()
        {
            var config = new ConfigReader().GetConfig();
            var allDeckPaths = Directory.GetFiles(config.DeckDirectory);

            Console.WriteLine($"Found {allDeckPaths.Length} decks.");

            foreach (var deckPath in allDeckPaths)
            {
                var deckName = Path.GetFileNameWithoutExtension(deckPath);
                Console.WriteLine(deckName);
            }
        }
    }
}
