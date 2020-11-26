using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApp.XmlModels
{
	[Serializable]
	public class Row
	{
		//[XmlElement("Cols")]
		[XmlArray]
		public List<int> Cols { get; set; }
	}
}
