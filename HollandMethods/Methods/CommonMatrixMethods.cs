﻿using System;
using System.Collections.Generic;
using System.Text;

using HollandMethods.StatisticClasses;

namespace HollandMethods.Methods
{
	public static class CommonMatrixMethods
	{
		public static int[] FillArray (int min, int max, int taskCount)
		{
			int[] array = new int[taskCount];
			Random random = new Random();

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = random.Next(min, max);
			}

			return array;
		}

		public static Array ResizeMatrix(Array arr, int n, int m)
		{
			var temp = Array.CreateInstance(arr.GetType().GetElementType(), n, m);
			int length = arr.Length <= temp.Length ? arr.Length : temp.Length;
			Array.ConstrainedCopy(arr, 0, temp, 0, length);

			return temp;
		}
	}
}
