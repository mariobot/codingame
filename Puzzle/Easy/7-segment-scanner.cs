using System;
using System.Linq;
using System.Collections.Generic;

class S
{
    static void Main(string[] args)
    {
        string line1 = Console.ReadLine();
        string line2 = Console.ReadLine();
        string line3 = Console.ReadLine();
        int countNumbers = line1.Length/3;
        
        string r1 = " _     _  _     _  _  _  _  _ ";
        string r2 = "| |  | _| _||_||_ |_   ||_||_|";
        string r3 = "|_|  ||_  _|  | _||_|  ||_| _|";
        Dictionary<int,string> dic = new Dictionary<int, string>();
        List<int> result = new List<int>();
        for(int i = 0; i < 10; i++)
        {
            int index = i * 3;
            string num = r1[index].ToString()+r1[index+1]+r1[index+2];
            num += r2[index].ToString()+r2[index+1]+r2[index+2];
            num += r3[index].ToString()+r3[index+1]+r3[index+2];
            dic.Add(i,num);
        }

        for(int i = 0; i < countNumbers; i++)
        {
            int index = i * 3;
            string num = line1[index].ToString()+line1[index+1]+line1[index+2];
            num += line2[index].ToString()+line2[index+1]+line2[index+2];
            num += line3[index].ToString()+line3[index+1]+line3[index+2];
            var Key = dic.FirstOrDefault(x => x.Value == num).Key;
            result.Add(Key);
        }

        Console.WriteLine(string.Join("",result));
    }
}