using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HollandMethods.GeneticClasses;
using HollandMethods.Methods;

using WebApp.Models;

namespace WebApps.Models
{
	public class SpecieModel
	{
		public List<GeneModel> Genes { get; set; }

		public int Fitness { get; set; }

		public int[,] GenesMatrix { get; set; }

		public SpecieModel(Specie specie)
		{
			GenesMatrix = new int[1, specie.Tasks.GetLength(1)];
			Genes = new List<GeneModel>();

			foreach (var gene in specie.Genes)
			{
				Genes.Add(new GeneModel(gene));
			}

			Fitness = specie.Fitness;
		}
	}
}