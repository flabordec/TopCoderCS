using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.StoneGameIII
{
    public class SolutionDynamicProgramming
    {
        public string StoneGameIII(int[] stoneValue)
        {
            int[] possibilities = new int[3];
            int[] bestScore = new int[stoneValue.Length + 2];
            bestScore[stoneValue.Length - 1] = stoneValue[stoneValue.Length - 1];
            for (int i = stoneValue.Length - 2; i >= 0; i--)
            {
                int accumulator = 0;
                for (int j = 0; j < 3 && i + j < stoneValue.Length; j++)
                {
                    int ix = i + j;
                    accumulator += stoneValue[ix];
                    possibilities[j] = accumulator - bestScore[ix + 1];
                }
                bestScore[i] = possibilities.Max();
            }
            if (bestScore[0] > 0)
                return "Alice";
            else if (bestScore[0] < 0)
                return "Bob";
            else
                return "Tie";
        }
    }

    public class SolutionTrash
    {
        public string StoneGameIII(int[] stoneValue)
        {
            int winner = Solve(stoneValue, 0, true, 0, 0);
            if (winner == 1)
                return "Alice";
            else if (winner == 2)
                return "Bob";
            else
                return "Tie";
        }

        public int Solve(int[] stoneValue, int ix, bool isPlayer1, int score1, int score2)
        {
            if (ix == stoneValue.Length)
            {
                if (score1 > score2)
                    return 1;
                else if (score2 > score1)
                    return 2;
                else
                    return -1;
            }

            bool anyTies = false;
            for (int i = 0; i < 3 && ix + i < stoneValue.Length; i++)
            {
                if (isPlayer1)
                    score1 += stoneValue[ix + i];
                else
                    score2 += stoneValue[ix + i];

                int winner = Solve(stoneValue, ix + i + 1, !isPlayer1, score1, score2);
                if (isPlayer1 && winner == 1)
                    return 1;
                if (!isPlayer1 && winner == 2)
                    return 2;

                if (winner == -1)
                    anyTies = true;
            }

            if (anyTies)
                return -1;
            else
                return isPlayer1 ? 2 : 1;
        }
    }
}
