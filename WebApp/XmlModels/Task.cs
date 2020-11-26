using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApp.XmlModels
{
	[Serializable]
	public class Task
	{
		[XmlArray]
		public List<Row> Rows { get; set; }
	}
}
