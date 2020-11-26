using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HollandWeb.Models
{
	public class SpecieModel
	{
		public List<GeneModel> Genes { get; set; }

		public int[,] GenesMatrix { get; set; }
	}
}