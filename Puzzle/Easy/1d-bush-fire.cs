using System;
using System.Text;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            Console.WriteLine(Calculation(line));
        }
    }

    public static int Calculation(string line)
    {
        StringBuilder sb = new StringBuilder(line);
        int count = 0;
        bool allPoints = true;
        while(allPoints)
        {
            int ind = sb.ToString().IndexOf('f');
            if(ind >= 0)
            {
                sb[ind] = '.';
                if(ind < sb.Length-1)
                    sb[ind+1] = '.';
                if(ind < sb.Length-2)
                    sb[ind+2] = '.';
                count += 1;
            }
            else            
                allPoints = false;
        }
        return count;
    }
}