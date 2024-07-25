using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        int floors = CalcFloors(N);

        for(int floor = 1; floor <= floors; floor++)
            PrintFloor(floors, floor);
    }

    public static void PrintFloor(int floors, int floor)
    {
        int w = floors - floor;        
        Console.WriteLine(new string(' ',w*3)+string.Join(" ", Enumerable.Repeat(" *** " , floor ))+new string(' ',w*3));
        Console.WriteLine(new string(' ',w*3)+string.Join(" ", Enumerable.Repeat(" * * " , floor ))+new string(' ',w*3));
        Console.WriteLine(new string(' ',w*3)+string.Join(" ", Enumerable.Repeat(" * * " , floor ))+new string(' ',w*3));
        Console.WriteLine(new string(' ',w*3)+string.Join(" ", Enumerable.Repeat("*****" , floor ))+new string(' ',w*3));
    }

    public static int CalcFloors(int N)
    {
        int y = 0;
        int lev = 0;
        
        if(N == 1) return 1;

        for(int i = 1; i <= N; i++)
        {
            y += i;
            if(y <= N)            
                lev += 1;            
            else
                return lev;
        }

        return 0;
    }
}