using System;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int sum = 0;

        int startLev = ReturnLevel(N);
        
        for(int i = startLev; i <= N; i++)
        {
            Console.WriteLine(new string('*',i));
            sum += i;
            if(sum == N)
                break;
        }
    }

    public static int CheckLevel(int N, int level)
    {
        int sum = 0;
        for(int i = level; i <= N*10; i++)
        {
            sum += i;
            if(sum == N)            
                return level;            
        }
        return 0;
    }

    public static int ReturnLevel(int N)
    {
        for(int i = 0; i <= 8; i++)
        {
            int lev = CheckLevel(N, i);
            if( lev != 0)
                return lev;
        }

        return 0;
    }
}