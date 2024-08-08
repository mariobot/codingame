using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        string wife = Console.ReadLine();
        string husband = Console.ReadLine();
        int w = LCM(wife.Length, husband.Length);

        Console.WriteLine(string.Join("", Enumerable.Repeat(wife, w/wife.Length)));
        PrintBody(wife, husband, w);
        Console.WriteLine(string.Join("", Enumerable.Repeat(husband, w/husband.Length)));
    }

    public static void PrintBody(string wife, string husband, int w)
    {
        for(int i = 0; i < w; i++)
        {
            int w1 = i;
            int h1 = i;
            if(i >= wife.Length)
                w1 = i % wife.Length;
            if(i >= husband.Length)
                h1 = i % husband.Length;

            Console.WriteLine(husband[h1]+new string(' ', w-2)+wife[w1]);
        }
    }

    public static int LCM(int a, int b)
    {
        int num1, num2;

        if (a > b)
        {
            num1 = a;
            num2 = b;
        }
        else
        {
            num1 = b;
            num2 = a;
        }

        for (int i = 1; i <= num2; i++)
        {
            if ((num1 * i) % num2 == 0)
            {
                return i * num1;
            }
        }
        return num2;
    }
}