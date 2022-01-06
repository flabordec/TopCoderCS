using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

class Solution_AbsolutePermutation
{
    static int[] AbsolutePermutation(int N, int k)
    {
        int[] ret;
        if (k == 0)
        {
            ret = new int[N];
            for (int i = 0; i < N; i++)
                ret[i] = i + 1;
            return ret;
        }

        if (N % (2 * k) != 0)
            return new int[] { -1 };

        ret = new int[N];
        int n = 0;
        while (n < N)
        {
            for (int i = 0; i < k; i++)
            {
                ret[n++] = n + k;
            }
            for (int i = 0; i < k; i++)
            {
                ret[n++] = n - k;
            }
        }
        return ret;
    }
}
