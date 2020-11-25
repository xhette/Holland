using System;
using System.Collections.Generic;
using System.Text;

using HollandMethods.GeneticClasses;

namespace HollandMethods.StatisticClasses
{
	public class StatisticModel
	{
		public StartGenerationTypeEnum StartGenerationType { get; set; }

		public int[,] Tasks { get; set; }

		public int RepeatsCount { get; set; }

		public int GenerationsCount { get; set; }

		public Specie BestSpecie { get; set; }

		public TimeSpan ProcessingTime { get; set; }

		public string StartGenerationTypeString
		{
			get
			{
				if (StartGenerationType == StartGenerationTypeEnum.CriticalWay)
				{
					return "Критический путь";
				}
				else if (StartGenerationType == StartGenerationTypeEnum.Random)
				{
					return "Случайно";
				}
				else
				{
					return "";
				}
			}
		}

		public StatisticModel() { }

		public StatisticModel(StatisticModel statistic)
		{
			StartGenerationType = statistic.StartGenerationType;

			Tasks = new int[statistic.Tasks.GetLength(0), statistic.Tasks.GetLength(1)];

			for (int i = 0; i < statistic.Tasks.GetLength(0); i++)
			{
				for (int j = 0; j < statistic.Tasks.GetLength(1); j++)
				{
					Tasks[i, j] = statistic.Tasks[i, j];
				}
			}

			RepeatsCount = statistic.RepeatsCount;
			GenerationsCount = statistic.GenerationsCount;
			BestSpecie = new Specie(statistic.BestSpecie);
			ProcessingTime = statistic.ProcessingTime;
		}
	}
}
