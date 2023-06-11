using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace CockatriceDeckListTool.Model
{
	[XmlRoot(ElementName = "cockatrice_deck")]
	public class CockatriceDeck
	{
		[XmlElement(ElementName = "deckname")]
		public string Deckname { get; set; }
		[XmlElement(ElementName = "comments")]
		public string Comments { get; set; }
		[XmlElement(ElementName = "zone")]
		public List<Zone> Zone { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }

		public Zone GetMainZone()
        {
			return Zone.First(x => x.Name == "main");
		}
    }
}
