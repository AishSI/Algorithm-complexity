using System.Linq;

namespace Recognizer
{
	public static class ThresholdFilterTask
	{
		public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
		{
			var sizePicture = new int[2] { original.GetLength(0), original.GetLength(1) };
			var n = original.Length;
			var pictureAfterThresholdFilter = new double[sizePicture[0], sizePicture[1]];
			int minNumberWhitePixels = (int)(whitePixelsFraction * n);


			if (minNumberWhitePixels == 0 || minNumberWhitePixels >= n)
				return boundaryCases(sizePicture, n, pictureAfterThresholdFilter, minNumberWhitePixels);

			var listOriginal = original.Cast<double>().OrderByDescending(i => i).ToList();
			double valueThresholdPixel = listOriginal[minNumberWhitePixels - 1];

			for (int x = 0; x < sizePicture[0]; x++)
				for (int y = 0; y < sizePicture[1]; y++)
				{
					if (original[x, y] >= valueThresholdPixel)
						pictureAfterThresholdFilter[x, y] = 1.0;
					else
						pictureAfterThresholdFilter[x, y] = 0.0;
				}
			return pictureAfterThresholdFilter;
		}

		private static double[,] boundaryCases(int[] sizePicture, int n,
			double[,] pictureAfterThresholdFilter, int minNumberWhitePixels)
		{
			double p = 0.0;
			if (minNumberWhitePixels == 0)
				p = 0.0;
			else if (minNumberWhitePixels >= n)
				p = 1.0;
			for (int x = 0; x < sizePicture[0]; x++)
				for (int y = 0; y < sizePicture[1]; y++)
				{
					pictureAfterThresholdFilter[x, y] = p;
				}
			return pictureAfterThresholdFilter;
		}
	}
}