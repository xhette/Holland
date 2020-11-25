using System;

using HollandMethods.Methods;
using HollandMethods.StatisticClasses;

namespace HollandMethods
{
	class Program
	{
		static void Main(string[] args)
		{
			//HollandModel holland1 = new HollandModel(20, 4, 10, 20, 100, 50, StatisticClasses.StartGenerationTypeEnum.CriticalWay);

			HollandStatistics statistics = new HollandStatistics(20, 4, 10, 20, 100, 50, 2);
			statistics.FeelStatistics();

			var statisticList = statistics.Statistics;
		}
	}
}
