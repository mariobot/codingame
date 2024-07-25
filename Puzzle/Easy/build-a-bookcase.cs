using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());
        int numberOfShelves = int.Parse(Console.ReadLine());

        PrintTop(width);
        PrintBody(height, width, numberOfShelves);
    }

    public static void PrintBody(int height, int width, int num)
    {
        int newHeight = (height - 1);
        bool isPerfect = (newHeight % num == 0);

        if(isPerfect)
        {
            int w = newHeight / num;
            for(int i = 1; i <= newHeight; i = i + w)
            {
                if((i % num == num))                
                    Console.WriteLine("|"+new string(' ', width-2)+"|");
                else
                    Console.WriteLine("|"+new string('_', width-2)+"|");
            }
        }
        else
        {
            int diff = newHeight % num;

            List<int> l = new List<int>();
            for(int i = 0; i < num; i++)            
                l.Add(newHeight / num);

            int g = 1;
            for(int i = 1; i <= diff; i++)
            {
                l[l.Count()-g] = (newHeight / num) + 1;
                g += 1;
            }

            foreach(int i in l)               
            {
                for(int j = 1; j <= i; j++)
                {
                    if(j == i)                
                        Console.WriteLine("|"+new string('_', width-2)+"|");
                    else
                        Console.WriteLine("|"+new string(' ', width-2)+"|");
                }
            }
        }
    }

    public static void PrintTop(int width)
    {
        bool isEven = (width % 2 == 0);
        int middle = isEven ? width/2 : (width-1)/2;
        if(isEven)
            Console.WriteLine(new string('/',middle)+new string('\\',middle));
        else
            Console.WriteLine(new string('/',middle)+"^"+new string('\\',middle));
    }
}