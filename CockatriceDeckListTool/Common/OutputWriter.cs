using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CockatriceDeckListTool.Common
{
    public class OutputWriter
    {
        public void WriteResult(Dictionary<string, int> cardCountDictionary)
        {
            var sorted = cardCountDictionary.OrderByDescending(x => x.Value).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var kv in sorted)
            {
                sb.Append($"{kv.Value} {kv.Key}{Environment.NewLine}");
            }

            File.WriteAllText("result.txt", sb.ToString());
        }
    }
}
