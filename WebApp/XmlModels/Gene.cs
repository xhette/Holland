using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApp.XmlModels
{
	[Serializable]
	[XmlType("Gene")]
	public class Gene
	{
		[XmlElement("Row")]
		public int Row { get; set; }

		[XmlElement("Processor")]
		public int Processor { get; set; }

		[XmlElement("ProcessingTime")]
		public int ProcessingTime { get; set; }
	}
}
