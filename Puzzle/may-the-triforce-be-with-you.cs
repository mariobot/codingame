using System;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int count = 1;
        int minf = 0;
        int countj = 0;
        int county = 1;
        int found = N*2-1;

        for(int i = 0; i <= found; i++)
        {
            if(i < N)
            {
                if(i == 0)
                {
                    Console.WriteLine($".{new string(' ',found-i-1)}{new string('*',i+count)}");
                }
                else
                {
                    Console.WriteLine($"{new string(' ',found-i)}{new string('*',i+count)}");
                }
                count += 1;
            }
            else
            {

                Console.WriteLine($"{new string(' ',N-county)}{new string('*',countj+county)}{new string(' ',found-minf)}{new string('*',countj+county)}");
                county += 1;
                countj += 1;
                minf += 2;
            }
        }
    }
}