using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using HollandMethods.Methods;

namespace HollandMethods.StatisticClasses
{
	public class HollandStatistics
	{
		public List<StatisticModel> Statistics { get; private set; }
		public string FolderPath { get; private set; }
		public string FolderName { get; private set; }

		int _taskCount;
		int _procCount;
		int _speciesCount;
		int _minLoad;
		int _maxLoad;
		int _repeatsCount;
		int _matrixCount;

		public HollandStatistics(int taskCount, int procCount, int speciesCount, int minLoad, int maxLoad, int repeatsCount, int matrixCount, string folderPath)
		{
			 _taskCount = taskCount;
			 _procCount = procCount;
			 _speciesCount = speciesCount;
			 _minLoad = minLoad;
			 _maxLoad = maxLoad;
			 _repeatsCount = repeatsCount;
			 _matrixCount = matrixCount;

			Statistics = new List<StatisticModel>();

			FolderPath = folderPath;
			FolderName = Guid.NewGuid().ToString();
		}

		void GoRandom(int[] tasks, int id)
		{
			int[,] start = StartGenerationRender.RandomWay(tasks, _procCount);
			var holland = new HollandModel(start, _speciesCount, _repeatsCount, StartGenerationTypeEnum.Random, FolderPath, FolderName, id);
			holland.Run();

			Statistics.Add(new StatisticModel(holland.Statistic, tasks));
		}

		void GoCriticalWay(int[] tasks, int id)
		{
			int[,] start = StartGenerationRender.CriticalWay(tasks, _procCount);
			var holland = new HollandModel(start, _speciesCount, _repeatsCount, StartGenerationTypeEnum.CriticalWay, FolderPath, FolderName, id);
			holland.Run();

			Statistics.Add(new StatisticModel(holland.Statistic, tasks));
		}

		public void FeelStatistics()
		{
			int id = 0;

			for (int i = 0; i < _matrixCount; i++)
			{
				int[] tasks = CommonMatrixMethods.FillArray(_minLoad, _maxLoad, _taskCount);
				GoRandom(tasks, id);
				GoCriticalWay(tasks, id);

				id++;
			}
		}
	}
}
