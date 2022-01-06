using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ContestScoreboard
{
	class Problem : IComparable<Problem>
	{
		public string TeamName { get; set; }
		public int Score { get; set; }
		public int Time { get; set; }

		public Problem(string team, int score, int time)
		{
			this.TeamName = team;
			this.Score = score;
			this.Time = time;
		}

		public int CompareTo(Problem other)
		{
			return this.Time.CompareTo(other.Time);
		}
	}

	class Team : IComparable<Team>
	{
		public int Score { get; set; }
		public string TeamName { get; set; }

		public Team(string teamName)
		{
			this.TeamName = teamName;
		}

		public int CompareTo(Team other)
		{
			if (this.Score == other.Score)
				return this.TeamName.CompareTo(other.TeamName);
			else
				return other.Score.CompareTo(this.Score);
		}
	}

	public int[] findWinner(string[] scores)
	{
		List<Problem> problems = new List<Problem>();
		List<Team> teams = new List<Team>();
		HashSet<string> winners = new HashSet<string>();
		for (int i = 0; i < scores.Length; i++)
		{
			string[] values = scores[i].Split(' ');
			string teamName = values[0];

			teams.Add(new Team(teamName));

			ParseScore(scores[i], problems);
		}

		teams.Sort();
		problems.Sort();
		
		Console.WriteLine("Leaders: {0}", string.Join(",", teams.Select(t => t.TeamName)));
		winners.Add(teams[0].TeamName);

		int lastTime = problems.First().Time;
		foreach (Problem problem in problems)
		{
			if (lastTime != problem.Time)
			{
				teams.Sort();
				Console.WriteLine("Leaders: {0}", string.Join(",", teams.Select(t => t.TeamName)));
				winners.Add(teams[0].TeamName);

				lastTime = problem.Time;
			}

			//Console.WriteLine("Team {0} answered in {1} for {2} points", 
			//	problem.TeamName, problem.Time, problem.Score);

			Team team = (
				from t in teams
				where t.TeamName == problem.TeamName
				select t
				).Single();

			team.Score += problem.Score;
		}

		teams.Sort();
		Console.WriteLine("Leaders: {0}", string.Join(",", teams.Select(t => t.TeamName)));
		winners.Add(teams[0].TeamName);

		List<int> result = new List<int>();
		for (int i = 0; i < scores.Length; i++)
		{
			string[] values = scores[i].Split(' ');
			string teamName = values[0];

			if (winners.Contains(teamName))
				result.Add(1);
			else
				result.Add(0);
		}
		return result.ToArray();
	}

	private void ParseScore(string scoreLine, List<Problem> problems)
	{
		string[] values = scoreLine.Split(' ');
		string teamName = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			string[] probParts = values[i].Split('/');
			int score = int.Parse(probParts[0]);
			int time = int.Parse(probParts[1]);

			problems.Add(new Problem(teamName, score, time));
		}
	}
}
