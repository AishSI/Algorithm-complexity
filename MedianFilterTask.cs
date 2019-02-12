using System;
using System.Collections.Generic;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		public static double[,] MedianFilter(double[,] original)
		{
			var sizePicture = new int[2] { original.GetLength(0), original.GetLength(1) };
			var pictureAfterMedianFilter = new double[sizePicture[0], sizePicture[1]];
			var listMedian = new List<double>();

			for (int x = 0; x < sizePicture[0]; x++)
				for (int y = 0; y < sizePicture[1]; y++)
				{
					var fieldMedian = new List<double>();
					MedianArea(original, sizePicture, x, y, fieldMedian);
					pictureAfterMedianFilter[x, y] = CalculateMedian(fieldMedian);
				}
			return pictureAfterMedianFilter;
		}

		private static void MedianArea(double[,] original, int[] sizePicture, int x, int y, List<double> fieldMedian)
		{
			for (int w = x - 1; w < x + 2; w++)
				for (int h = y - 1; h < y + 2; h++)
				{
					if (w >= 0 && h >= 0 && w < sizePicture[0] && h < sizePicture[1])
						fieldMedian.Add(original[w, h]);
					fieldMedian.Sort();
				}
		}

		private static double CalculateMedian(List<double> listMedian)
		{
			var centerMedian = listMedian.Count / 2;
			if (listMedian.Count == 1)
				return listMedian[0];
			if (listMedian.Count % 2 == 1)
				return listMedian[centerMedian];
			else
				return (listMedian[centerMedian-1] + listMedian[centerMedian]) / 2;
		}
	}
}