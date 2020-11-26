using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApp.XmlModels
{
	[Serializable]
	public class Specie
	{
		[XmlArray("Genes")]
		public List<Gene> Genes { get; set; }

		public int Fitness { get; set; }

		public double Adaptation { get; set; }
	}
}
