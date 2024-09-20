using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] first = new int[8];
        
        for (int i = 0; i < n; i++)
        {
            string card = Console.ReadLine().Replace(" ","");
            int second = 0;
            int inc = 0;

            for(int j = card.Length-1; j >= 0; j--)
            {
                if(j % 2 == 0)
                {
                    int f = int.Parse(card[j].ToString())*2;
                    
                    if(f >= 10)
                        first[inc] = int.Parse(f.ToString()[0].ToString()) + int.Parse(f.ToString()[1].ToString());
                    else
                        first[inc] = f;

                    inc += 1;
                }
                else                
                    second += int.Parse(card[j].ToString());
            }

            int total = first.Sum() + second;

            if(total % 10 == 0)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}