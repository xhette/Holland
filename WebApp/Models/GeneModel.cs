using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HollandMethods.GeneticClasses;

namespace WebApp.Models
{
	public class GeneModel
	{
		public int Row { get; set; }
		public int Processor { get; set; }
		public int ProcessingTime { get; set; }

		public GeneModel(Gene gene)
		{
			Row = gene.Row;
			Processor = gene.Processor;
			ProcessingTime = gene.ProcessingTime;
		}
	}
}