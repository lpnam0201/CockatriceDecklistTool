using CockatriceDeckListTool.Model;
using CockatriceDeckListTool.Process;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = Enum.Parse<Operation>(args[0]);
            switch (operation)
            {
                case Operation.SleeveCount:
                    new SleeveCountProcess().Execute();
                    break;
                case Operation.CardUsageCount:
                    new CardUsageCountProcess().Execute();
                    break;
                case Operation.DeckDiff:
                    var deck1 = args[1];
                    var deck2 = args[2];
                    new DeckDiffProcess().Execute(deck1, deck2);
                    break;
                case Operation.ListDeck:
                    new ListDeckProcess().Execute();
                    break;
            }
        }

        
    }
}
