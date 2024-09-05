using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        long[] a = Console.ReadLine().Split(" ").Select(x => long.Parse(x)).ToArray();
        long[] b = Console.ReadLine().Split(" ").Select(x => long.Parse(x)).ToArray();
        long t = 0;
        long res = 0;
        int i = 0;
        int j = 0;

        while(i < a.Length)
        {
            t = Math.Min(a[i],b[j]);
            a[i] -= t;
            b[j] -= t;
            res += t * a[i+1] *b [j+1];
            if (a[i] == 0)
                i += 2;
            if (b[j] == 0)
                j += 2;
        }
        
        Console.WriteLine(res);
    }
}