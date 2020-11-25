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

		int _taskCount;
		int _procCount;
		int _speciesCount;
		int _minLoad;
		int _maxLoad;
		int _repeatsCount;
		int _matrixCount;

		public HollandStatistics(int taskCount, int procCount, int speciesCount, int minLoad, int maxLoad, int repeatsCount, int matrixCount)
		{
			 _taskCount = taskCount;
			 _procCount = procCount;
			 _speciesCount = speciesCount;
			 _minLoad = minLoad;
			 _maxLoad = maxLoad;
			 _repeatsCount = repeatsCount;
			 _matrixCount = matrixCount;

			Statistics = new List<StatisticModel>();
		}

		void GoRandom()
		{
			Parallel.For(0, _matrixCount, c =>
			{
				var holland = new HollandModel(_taskCount, _procCount, _speciesCount, _minLoad, _maxLoad, _repeatsCount, StartGenerationTypeEnum.Random);
				holland.Run();

				Statistics.Add(new StatisticModel(holland.Statistic));
			});
		}

		void GoCriticalWay()
		{
			Parallel.For(0, _matrixCount, c =>
			{
				var holland = new HollandModel(_taskCount, _procCount, _speciesCount, _minLoad, _maxLoad, _repeatsCount, StartGenerationTypeEnum.CriticalWay);
				holland.Run();

				Statistics.Add(new StatisticModel(holland.Statistic));
			});
		}

		public void FeelStatistics()
		{
			GoRandom();
			GoCriticalWay();
		}
	}
}
