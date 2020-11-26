using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.XmlModels
{
	[Serializable]
	public class Generation
	{
		public List<Specie> Species { get; set; }
	}
}
