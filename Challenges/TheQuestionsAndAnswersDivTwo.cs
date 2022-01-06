using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TheQuestionsAndAnswersDivTwo
{
	public int find(string[] questions)
	{
		int n = questions.Distinct().Count();
		int r = 1;
		for (int i = 0; i < n; i++)
			r *= 2;
		return r;
	}
}
