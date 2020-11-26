using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApp.XmlModels
{
	[Serializable]
	public class Root
	{
		public Task Tasks { get; set; }

		[XmlArray("Generations")]
		public List<Generation> Generations { get; set; }
	}
}
