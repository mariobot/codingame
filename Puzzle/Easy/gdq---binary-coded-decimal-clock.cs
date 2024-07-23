using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(":");
        List<Digit> list = new List<Digit>();

        for (int i = 0; i < 4; i++)
        {
            if(i == 1 || i == 2)
            {   
                int first = int.Parse(input[i][0].ToString());
                int second = int.Parse(input[i][1].ToString());

                Digit dFirst = CreateDigit(first);
                Digit dSecond = CreateDigit(second);

                list.Add(dFirst);
                list.Add(dSecond);
            }
            else
            {
                int first = int.Parse(input[i]);                
                Digit dFirst = CreateDigit(first);
                list.Add(dFirst);
            }
        }

        for(int i = 0; i < 4; i++)
        {
            string line = "|";
            
            foreach(Digit d in list)            
                line += new string(d.binary[i],5)+"|";

            Console.WriteLine(line);
        }
    }

    public class Digit
    {
        public int number { get; set; }
        public char[] binary { get; set; }
    }

    public static char[] ConvertToBin(int value)
    {
        return Convert.ToString(value, 2).PadLeft(4,'0').Replace("1","#").Replace("0","_").ToCharArray();
    }

    public static Digit CreateDigit(int value)
    {
        Digit digit = new Digit()
        {
            number = value,
            binary = ConvertToBin(value)
        };

        return digit;
    }
}