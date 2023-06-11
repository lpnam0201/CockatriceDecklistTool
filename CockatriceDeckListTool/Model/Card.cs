using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CockatriceDeckListTool.Model
{
	[XmlRoot(ElementName = "card")]
	public class Card
	{
		[XmlAttribute(AttributeName = "number")]
		public int Number { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
	}
}
