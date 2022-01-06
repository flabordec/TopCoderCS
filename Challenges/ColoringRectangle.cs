using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ColoringRectangle
{
	class ReverseComparer : IComparer<int>
	{
		public int Compare(int x, int y)
		{
			return y - x;
		}
	}


	private int Width { get; set; }
	private int Height { get; set; }
	private double HalfHeight { get; set; }

	public int chooseDisks(int width, int height, int[] red, int[] blue)
	{
		this.Width = width;
		this.Height = height;
		this.HalfHeight = height / 2.0;

		Array.Sort(red, new ReverseComparer());
		Array.Sort(blue, new ReverseComparer());
		int b = ChooseDisk(0, red, blue, 0, 0, true, 0);
		int r = ChooseDisk(0, red, blue, 0, 0, false, 0);
		if (b != -1 && r != -1)
			return Math.Min(b, r);
		else if (b != -1)
			return b;
		else
			return r;
	}

	private int ChooseDisk(double currentX, int[] red, int[] blue, int rix, int bix, bool lastRed, int nDisks) 
	{
		int[] arr = lastRed ? blue : red;
		int ix = lastRed ? bix : rix;
		if (ix >= arr.Length)
			return -1;
		
		int value = arr[ix];
		if (value < this.Height)
			return -1;

		double halfValue = value / 2.0;

		double width = Math.Sqrt((halfValue * halfValue) - (HalfHeight * HalfHeight));
		double nextX = currentX + (width * 2);

		if (nextX >= this.Width)
			return nDisks + 1;

		rix = lastRed ? rix : rix + 1;
		bix = lastRed ? bix + 1 : bix;
		int r = ChooseDisk(nextX, red, blue, rix, bix, !lastRed, nDisks + 1);

		return r;
	}
}

