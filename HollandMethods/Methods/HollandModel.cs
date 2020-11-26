using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using HollandMethods.GeneticClasses;
using HollandMethods.StatisticClasses;

namespace HollandMethods.Methods
{
	public class HollandModel
	{
		public int[,] Tasks { get; private set; }

		readonly Generation lastGeneration;
		Specie bestSpecie;

		public StatisticModel Statistic { get; private set; }

		readonly int repeatsCount;

		Logging logging;

		public HollandModel(int[,] tasks, int speciesCount, int repeatsCount, StartGenerationTypeEnum type, string folderPath, string folderName, int id)
		{
			Tasks = tasks;
			lastGeneration = new Generation(Tasks, speciesCount);
			bestSpecie = lastGeneration.BestSpecie();
			this.repeatsCount = repeatsCount;

			Statistic = new StatisticModel();

			Statistic.Tasks = Tasks;
			Statistic.StartGenerationType = type;
			Statistic.RepeatsCount = repeatsCount;
			Statistic.GenerationsCount = 0;

			logging = new Logging(folderPath, folderName, id, type, tasks);
		}

		private void Step()
		{
			lastGeneration.SpecieExchange();
		}

		public void Run()
		{
			Stopwatch startTime;
			TimeSpan resultTime;

			int currentRepeats = 0;
			startTime = Stopwatch.StartNew();
			startTime.Stop();

			while (currentRepeats < repeatsCount)
			{
				++ Statistic.GenerationsCount;

				logging.WriteGeneration(lastGeneration);

				Step();

				Specie currentBestSpecie = lastGeneration.BestSpecie();
				if (currentBestSpecie.Fitness < bestSpecie.Fitness)
				{
					currentRepeats = 0;
					bestSpecie = currentBestSpecie;
				}
				else
				{
					currentRepeats++;
				}
			}

			resultTime = startTime.Elapsed;
			Statistic.ProcessingTime = resultTime;
			Statistic.BestSpecie = bestSpecie;

			logging.StopLogging();
		}
	}
}