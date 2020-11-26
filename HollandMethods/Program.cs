using System;

using HollandMethods.Methods;
using HollandMethods.StatisticClasses;

namespace HollandMethods
{
	class Program
	{
		static void Main(string[] args)
		{
			HollandStatistics statistics = new HollandStatistics(20, 4, 10, 20, 100, 50, 1, @"D:\stud\KobakKurs");
			statistics.FeelStatistics();

			var statisticList = statistics.Statistics;
		}
	}
}
