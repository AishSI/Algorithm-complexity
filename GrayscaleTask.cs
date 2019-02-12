namespace Recognizer
{
	public static class GrayscaleTask
	{
		public static double[,] ToGrayscale(Pixel[,] original)
		{
			var x = original.GetLength(0);
			var y = original.GetLength(1);
			var gray = new double[x, y];
			for (int i = 0; i < x; i++)
				for (int j = 0; j < y; j++)
					ConvertToGray(original, gray, i, j);
			return gray;
		}

		private static void ConvertToGray(Pixel[,] original, double[,] gray, int i, int j)
		{
			gray[i, j] = (0.299 * original[i, j].R + 0.587 * original[i, j].G + 0.114 * original[i, j].B) / 255;
		}
	}
}