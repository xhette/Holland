using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HollandWeb.Models
{
	public class HollandModel
	{
		public int[] StartArray { get; set; }

		public int[,] Tasks { get; set; }

		public int RepeatsCount { get; set; }

		public int GenerationsCount { get; set; }

		public SpecieModel BestSpecie { get; set; }

		public TimeSpan ProcessingTime { get; set; }

		public string StartGenerationTypeString { get; set; }

		//public HollandModel(StatisticModel statistic)
		//{
			
		//}
	}
}