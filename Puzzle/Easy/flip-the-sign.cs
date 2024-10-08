using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int height = int.Parse(inputs[0]);
        int width = int.Parse(inputs[1]);
        
        List<int> list = new List<int>();
        List<bool> listBool = new List<bool>();
        List<int> values = new List<int>();
        
        for (int i = 0; i < height; i++)        
            list.AddRange(Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList());
        
        for (int i = 0; i < height; i++)        
            listBool.AddRange(Console.ReadLine().Split(" ").Select(x => x == "X").ToList());        

        for(int i = 0; i < list.Count; i++)
        {
            if(listBool[i])
                values.Add(list[i]);
        }

        int first = values.FirstOrDefault();
        bool Nomixed = true;

        if(first >= 0)
        {
            bool positive = true;
            for(int i = 0; i < values.Count(); i++)
            {
                if(positive)
                {
                    if(values[i] < 0)
                        Nomixed = false;
                }
                else
                {
                    if(values[i] >= 0)
                        Nomixed = false;
                }
                positive = positive ? false : true;
            }
        }
        else
        {
            bool positive = false;
            for(int i = 0; i < values.Count(); i++)
            {
                if(positive)
                {
                    if(values[i] < 0)
                        Nomixed = false;
                }
                else
                {
                    if(values[i] >= 0)
                        Nomixed = false;
                }
                positive = positive ? false : true;
            }
        }
        
        Console.WriteLine(Nomixed.ToString().ToLower());
    }
}