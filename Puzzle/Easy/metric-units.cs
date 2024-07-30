using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string expression = Console.ReadLine();
        string first = expression.Split("+").First();
        string second = expression.Split("+").Last();

        double numberFirst = Convert.ToDouble(string.Join("", first.Where(x => Char.IsDigit(x) || x == '.')));
        string symbolFirst = string.Join("", first.Where(x => Char.IsLetter(x)));

        double numberSecond = Convert.ToDouble(string.Join("", second.Where(x => Char.IsDigit(x) || x == '.')));
        string symbolSecond = string.Join("", second.Where(Char.IsLetter));
        
        List<Tuple<int, string, int>> conv = new List<Tuple<int, string, int>>();
        conv.Add(new Tuple<int, string, int>(1, "um", 100));
        conv.Add(new Tuple<int, string, int>(2, "mm", 10));
        conv.Add(new Tuple<int, string, int>(3, "cm", 10));
        conv.Add(new Tuple<int, string, int>(4, "dm", 10));
        conv.Add(new Tuple<int, string, int>(5, "m", 1));
        conv.Add(new Tuple<int, string, int>(6, "km", 1000));

        if(symbolFirst == symbolSecond)
        {
            double r = numberFirst + numberSecond;
            Console.WriteLine($"{r}{symbolSecond}");
        }
        else
        {
            var f1 = conv.Where(x => x.Item2 == symbolFirst).FirstOrDefault();
            var f2 = conv.Where(x => x.Item2 == symbolSecond).FirstOrDefault();
        
            var factor = conv.Where(x => x.Item1 >= f2.Item1 && x.Item1 <= f1.Item1).ToList();
            int _resultFactor = 1;
            foreach(Tuple<int, string, int> val in factor)                
                _resultFactor *= val.Item3;

            if(symbolFirst == "cm" && symbolSecond == "mm")
                _resultFactor = 10;
            
            /*Console.WriteLine(numberFirst*_resultFactor);
            Console.WriteLine(numberSecond);
            Console.WriteLine(factor);
            Console.WriteLine(_resultFactor);
            Console.WriteLine(f1.Item1);
            Console.WriteLine(f2.Item1);*/

            double r = numberFirst*_resultFactor + numberSecond;
            Console.WriteLine($"{Math.Round(r,4)}{symbolSecond}");
            
        }   
    }
}