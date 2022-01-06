using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PaperAndPaintEasy
{
	public long computeArea(
		int width, int height, int xfold, int cnt, int x1, int y1, int x2, int y2)
	{
		return InnerComputeArea(width, height, xfold, cnt, x1, y1, x2, y2);
	}

	public long InnerComputeArea(
		long width, long height, long xfold, long cnt, long x1, long y1, long x2, long y2)
	{
		xfold = Math.Min(xfold, width - xfold);

		long totalArea = width * height;
		long paintedArea = (y2 - y1) * (x2 - x1);
		long paintedAreaCnt = paintedArea * (cnt + 1);

		long paintedAreaX;
		if (xfold <= x1)
			paintedAreaX = 0;
		else if (xfold > x1 && xfold < x2)
			paintedAreaX = (xfold - x1) * (y2 - y1);
		else
			paintedAreaX = (x2 - x1) * (y2 - y1);
		long paintedAreaXCnt = paintedAreaX * (cnt + 1);

		long paintedAreaTotal = paintedAreaCnt + paintedAreaXCnt;

		Console.WriteLine("Painted: {0}", paintedArea);
		Console.WriteLine("Painted Cnt: {0}", paintedAreaCnt);
		Console.WriteLine("Painted XFold: {0}", paintedAreaX);
		Console.WriteLine("Painted Total: {0}", paintedAreaTotal);

		return totalArea - paintedAreaTotal;
	}

	public long InnerComputeArea2(
		int width, int height, int xfold, int cnt, int x1, int y1, int x2, int y2)
	{
		
		long paintedArea = ((long)y2 - y1) * (x2 - x1);
		long ret;
		if (xfold <= x1)
			ret = paintedArea * (cnt + 1);
		else if (xfold > x1 && xfold < x2)
			ret = (((long)xfold - x1) * 2 + (x2 - xfold)) * (y2 - y1) * (cnt + 1);
		else
			ret = ((long)x2 - x1) * 2 * (y2 - y1) * (cnt + 1);
		return (long)width * height - ret;
	}
}
