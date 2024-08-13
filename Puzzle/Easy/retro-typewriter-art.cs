using System;
using System.Linq;
using System.Text;

class Solution
{
    static void Main(string[] args)
    {
        string T = Console.ReadLine();
        string[] iL = T.Split(' ');

        foreach(string ins in iL)
        {
            char[] t = ins.ToCharArray();

            if(ins.Contains("sp")||ins.Contains("bS")||ins.Contains("sQ")||ins.Contains("nl"))
            {
                if(ins.Contains("nl"))
                {
                    Console.WriteLine();
                    continue;
                }

                string result = "";
                for (int i = 0; i < t.Length - 2; i++) 
                {
                    result += t[i];
                }

                int numberOfTimes = int.Parse(result);

                if(ins.Contains("sp"))
                    Console.Write(StringExtensions.Repeat(' '.ToString(),numberOfTimes));
                if(ins.Contains("bS"))
                    Console.Write(StringExtensions.Repeat(@"\".ToString(),numberOfTimes));
                if(ins.Contains("sQ"))
                    Console.Write(StringExtensions.Repeat(@"'".ToString(),numberOfTimes));
            }            
            else
            {
                string result = "";

                for (int i = 0; i < t.Length - 1; i++)
                {
                    result += t[i];
                }

                int numberOfTimes = int.Parse(result);
                Console.Write(StringExtensions.Repeat(t.Last().ToString(),numberOfTimes));
            }
        }
    }
}

public static class StringExtensions
    {
        public static string Repeat(this string s, int n)
            => new StringBuilder(s.Length * n).Insert(0, s, n).ToString();
    }