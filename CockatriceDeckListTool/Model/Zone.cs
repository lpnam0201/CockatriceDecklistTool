using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CockatriceDeckListTool.Model
{
	[XmlRoot(ElementName = "zone")]
	public class Zone
	{
		[XmlElement(ElementName = "card")]
		public List<Card> Card { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
	}
}
