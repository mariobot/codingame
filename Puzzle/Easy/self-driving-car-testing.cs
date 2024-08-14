using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string xthenCommands = Console.ReadLine();

        List<string> commands = xthenCommands.Split(";").ToList();
        int position = Convert.ToInt16(commands.First())-1;
        commands.Remove(commands.First());

        List<string> mov = new List<string>();
        List<string> road = new List<string>();

        foreach(string comm in commands)
        {
            int Num = Convert.ToInt16(string.Concat(comm.Where(Char.IsDigit)));
            string Letter = string.Concat(comm.Where(Char.IsLetter));

            for(int k = 0; k < Num; k++)
                mov.Add(Letter);
        }

        for (int i = 0; i < N; i++)
        {
            string Roadpattern = Console.ReadLine();
            int repeat = Convert.ToInt16(Roadpattern.Split(";").First());
            string pattern = Roadpattern.Split(";").Last();
            for(int  j = 0; j < repeat; j++)
            {
                road.Add(pattern);
            }
        }

        for (int i = 0; i < mov.Count(); i++)
        {
            string pattern = road[i];
            string mo = mov[i];

            if(mo == "S")
            {
                StringBuilder sb = new StringBuilder(pattern);
                sb[position] = '#'; 
                pattern = sb.ToString();
            }
            
            if(mo == "R")
            {
                StringBuilder sb = new StringBuilder(pattern);
                position += 1;
                sb[position] = '#'; 
                pattern = sb.ToString();
            }
            
            if(mo == "L")
            {
                StringBuilder sb = new StringBuilder(pattern);
                position -= 1;
                sb[position] = '#'; 
                pattern = sb.ToString();
            }

            Console.WriteLine(pattern);
        }
    }
}