using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OmegaUp_RepositoryManagementTool
{
	static void Main(string[] args)
	{
		var packages = new HashSet<string>();
		string[] splitLine;
		int n = int.Parse(Console.ReadLine());
		
		for (int i = 0; i < n; i++)
		{
			splitLine = Console.ReadLine().Split(' ');
			int packageCount = Convert.ToInt32(splitLine[1]);
			for (int j = 0; j < packageCount; j++)
			{
				string package = Console.ReadLine();
				packages.Add(package);
			}
		}

		var orderedPackages = packages.OrderBy(
			s =>
			{
				string[] split = s.Split(' ');
				string name = split[0];
				int version = Convert.ToInt32(split[1]);
				return new Tuple<string, int>(name, version);
			});
		Console.WriteLine(string.Join("\n", orderedPackages));
	}
}