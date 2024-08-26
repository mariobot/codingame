using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

class Solution
{
    static async Task Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int Width = (N * 2) - 1;
        List<List<char>> list = new List<List<char>>();
        for (int i = 0; i < N; i++)
        {
            string ROW = Console.ReadLine();
            List<char> lc = ROW.ToCharArray().ToList();
            list.Add(lc);
        }
        bool containBackSlash = false;
        if(list.Where(x => x.Contains('/')).Count() > 0 || list.Where(x => x.Contains('\\')).Count() > 0)
            containBackSlash = true;
       
        // Copy the last rows
        for(int j = N-2; j >= 0; j--)
        {
            List<char> newList = list[j].GetRange(0, list[j].Count);
            list.Add(newList);
        }

        // Copy the second section
        for(int i = 0; i < N; i++)
        {
            for(int j = N-2; j >= 0; j--)
            {
                if(containBackSlash)
                    list[i].Add(MirrorChar3(list[i][j]));
                else
                    list[i].Add(MirrorChar(list[i][j]));
            }
        }

        // Compute the third section
        for(int i = N; i <= list.Count()-1; i++)
        { 
            for(int j = 0; j < list[i].Count()-1; j++)
            {
                if(containBackSlash)
                    list[i][j] = MirrorChar4(list[i][j]);
                else
                    list[i][j] = list[i][j];
            }
        }

        // Copy the forth section
        for(int i = N; i <= list.Count()-1; i++)
        { 
            for(int j = N-2; j >= 0; j--)
            {
                list[i].Add(MirrorChar3(list[i][j]));
            }
        }

        Parallel.ForEach(Enumerable.Range(0, list.Count), i =>
        {
            if (i >= N)
            {
                List<char> sublist = list[i];
                int sublistCount = sublist.Count;
                List<char> tempResults = new List<char>();

                for (int j = 0; j < sublistCount; j++)                
                    list[i][j] = MirrorChar2(list[i][j]);
            }
        });

        Print(list, Width);
    }

    public static void Print(List<List<char>> data, int width)
    {
        Console.WriteLine($"+{new string('-',width)}+{new string('-',width)}+");
        foreach(List<char> lc in data)        
             Console.WriteLine($"|{string.Join("",lc)}|{string.Join("",lc)}|");
        Console.WriteLine($"+{new string('-',width)}+{new string('-',width)}+");
        foreach(List<char> lc in data)        
             Console.WriteLine($"|{string.Join("",lc)}|{string.Join("",lc)}|");
        Console.WriteLine($"+{new string('-',width)}+{new string('-',width)}+");
    }

    public static char MirrorChar(char input)
    {
        if(input == '(')
            return ')';
        if(input == ')')
            return '(';
        if(input == '{')
            return '}';
        if(input == '}')
            return '{';
        if(input == '[')
            return ']';
        if(input == ']')
            return '[';
        if(input == '<')
            return '>';
        if(input == '>')
            return '<';

        return input;
    }

    public static char MirrorChar2(char input)
    {
        if(input == '^')
            return 'v';
        if(input == 'v')
            return '^';
        if(input == 'A')
            return 'V';
        if(input == 'V')
            return 'A';
        if(input == 'w')
            return 'm';
        if(input == 'm')
            return 'w';
        if(input == 'W')
            return 'M';
        if(input == 'M')
            return 'W';
        if(input == 'u')
            return 'n';
        if(input == 'n')
            return 'u';

        return input;
    }

    public static char MirrorChar3(char input)
    {
        if(input == '(')
            return ')';
        if(input == ')')
            return '(';
        if(input == '{')
            return '}';
        if(input == '}')
            return '{';
        if(input == '[')
            return ']';
        if(input == ']')
            return '[';
        if(input == '<')
            return '>';
        if(input == '>')
            return '<';
        if(input == '/')
            return '\\';
        if(input == '\\')
            return '/';
        return input;
    }

    public static char MirrorChar4(char input)
    {
        if(input == '/')
            return '\\';
        if(input == '\\')
            return '/';
        return input;
    }
}