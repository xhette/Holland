using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HollandMethods.StatisticClasses;

using WebApps.Models;

namespace WebApp.Models
{
	public class HollandModel
	{
		public int Id { get; set; }

		public string FolherName { get; set; }

		public int[] StartArray { get; set; }

		public int[,] Tasks { get; set; }

		public int RepeatsCount { get; set; }

		public int GenerationsCount { get; set; }

		public SpecieModel BestSpecie { get; set; }

		public TimeSpan ProcessingTime { get; set; }

		public int StartGenerationTypeInt { get; set; }

		public string StartGenerationTypeString { get; set; }

		public HollandModel(StatisticModel statistic)
		{
			StartArray = new int[statistic.StartArray.Length];

			for (int i = 0; i < StartArray.Length; i++)
			{
				StartArray[i] = statistic.StartArray[i];
			}

			Tasks = new int[statistic.Tasks.GetLength(0), statistic.Tasks.GetLength(1)];

			for (int i = 0; i < statistic.Tasks.GetLength(0); i++)
			{
				for (int j = 0; j < statistic.Tasks.GetLength(1); j++)
				{
					Tasks[i, j] = statistic.Tasks[i, j];
				}
			}

			BestSpecie = new SpecieModel(statistic.BestSpecie);
			RepeatsCount = statistic.RepeatsCount;
			GenerationsCount = statistic.GenerationsCount;
			ProcessingTime = statistic.ProcessingTime;
			StartGenerationTypeString = statistic.StartGenerationTypeString;
			StartGenerationTypeInt = (int)statistic.StartGenerationType;
			Id = statistic.Id;
			FolherName = statistic.FolherName;
		}
	}
}