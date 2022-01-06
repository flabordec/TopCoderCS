using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FoxAndFencingEasy
{
	public string WhoCanWin(int mov1, int mov2, int d)
	{
		if (d <= mov1)
			return "Ciel";

		if (mov1 >= (mov2 * 2) + 1)
			return "Ciel";

		if (mov2 >= (mov1 * 2) + 1)
			return "Liss";

		return "Draw";
	}
}
