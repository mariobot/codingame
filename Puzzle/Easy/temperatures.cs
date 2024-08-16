using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        List<int> pos = new List<int>();
        List<int> neg = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]);
            if(t >= 0)
                pos.Add(t);
            else
                neg.Add(t);
        }

        if(pos.Count > 0 && neg.Count > 0)
        {
            int ptotal = pos.Min();
            int ntotal = neg.Max();

            if(ptotal == (ntotal*-1))
                Console.WriteLine(ptotal);
            else if(ptotal < (ntotal*-1))
                Console.WriteLine(ptotal);
            else
                Console.WriteLine(ntotal);
        }

        if(pos.Count > 0 && neg.Count == 0)
            Console.WriteLine(pos.Min());
        if(neg.Count > 0 && pos.Count == 0)        
            Console.WriteLine(neg.Max());
        if(neg.Count == 0 && pos.Count == 0)        
            Console.WriteLine(0);
    }
}