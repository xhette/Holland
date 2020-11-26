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
		int Row { get; set; }

		[XmlElement("Processor")]
		int Processor { get; set; }

		[XmlElement("ProcessingTime")]
		int ProcessingTime { get; set; }
	}
}
