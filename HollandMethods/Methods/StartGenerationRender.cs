using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollandMethods.Methods
{
	public static class StartGenerationRender
	{
		public static int[,] CriticalWay(int[] tasks, int n)
		{
			int[,] schedule = new int[1, n];
			int[] loads = new int[n];

			for (int i = 0; i < tasks.Length; i++)
			{
				// находим минимальную нагрузку
				int resultMin = loads.Min();
				int minIndex = Array.IndexOf(loads, resultMin);

				// находим последнюю строку в расписании
				int matrixRow = schedule.GetLength(0) - 1;

				// если ячейка занята, добавляем новую строку в матрицу
				if (schedule[matrixRow, minIndex] != 0)
				{
					int newRowsCount = schedule.GetLength(0) + 1;
					matrixRow++;

					schedule = (int[,])CommonMatrixMethods.ResizeMatrix(schedule, newRowsCount, schedule.GetLength(1));
				}

				// записываем элемент из списка заданий в ячейку расписаний
				schedule[matrixRow, minIndex] = tasks[i];
				int newResult = resultMin + tasks[i];

				// изменяем нагрузку
				loads[minIndex] = newResult;
			}

			return schedule;
		}

		public static int[,] RandomWay(int[] tasks, int n)
		{
			int[,] schedule = new int[1, n];

			for (int i = 0; i < tasks.Length; i++)
			{
				Random rnd = new Random();

				// находим минимальную нагрузку
				int minIndex = rnd.Next(0, n);

				// находим последнюю строку в расписании
				int matrixRow = schedule.GetLength(0) - 1;

				// если ячейка занята, добавляем новую строку в матрицу
				if (schedule[matrixRow, minIndex] != 0)
				{
					int newRowsCount = schedule.GetLength(0) + 1;
					matrixRow++;

					schedule = (int[,])CommonMatrixMethods.ResizeMatrix(schedule, newRowsCount, schedule.GetLength(1));
				}

				// записываем элемент из списка заданий в ячейку расписаний
				schedule[matrixRow, minIndex] = tasks[i];
			}

			return schedule;
		}
	}
}