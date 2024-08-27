using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int h = int.Parse(Console.ReadLine());
        List<(int[], bool)> list = new List<(int[], bool)>();
        for (int i = 0; i < h; i++)
        {
            string row = Console.ReadLine();
            int[] arrayRow;
            bool startZero = false;
            if(row.StartsWith("0"))
            {
                row = row.Remove(0, 2);
                arrayRow = row.Split(' ').Select(x => int.Parse(x)).ToArray();
                startZero = true;
            }
            else
            {
                arrayRow = row.Split(' ').Select(x => int.Parse(x)).ToArray();
            }
            list.Add(new (arrayRow, startZero));
        }

        char symbol = '.';
        int sumLine = list.FirstOrDefault().Item1.Sum();
        bool nolineal = false;
        
        for (int i = 0; i < h; i++)
        {
            if(sumLine !=  list[i].Item1.Sum())
                nolineal = true;
        }

        if(nolineal)
            Console.WriteLine("INVALID");
        else
        {
            for (int i = 0; i < h; i++)
            {
                var item = list[i];
                string line = "";

                if(item.Item2)            
                    symbol = 'O';            
                else            
                    symbol = '.';

                for(int j = 0; j < item.Item1.Length; j++)
                {
                    line += new string(symbol, item.Item1[j]);
                    symbol = symbol == 'O' ? '.' : 'O';                
                }

                Console.WriteLine(line);
            }
        }
    }
}