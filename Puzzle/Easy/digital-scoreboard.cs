using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        List<string> l = new List<string>();
        for (int i = 0; i < 23; i++)
        {
            string ROW = Console.ReadLine();
            l.Add(ROW);
        }

        List<Number> input = new List<Number>();
        List<Number> sub = new List<Number>();
        List<Number> add = new List<Number>();

        for (int i = 1; i <= 5; i++)
        {
            string ROW = l[i];
            string n1 = ROW.Substring(2,5); 
            string n2 = ROW.Substring(10,5);            
            //Console.WriteLine(n1 +"-"+ n2);
            Number n = new Number(n1,n2);
            input.Add(n);
        }

        for (int i = 9; i <= 13; i++)
        {
            string ROW = l[i];
            string n1 = ROW.Substring(2,5); 
            string n2 = ROW.Substring(10,5);
            //Console.WriteLine(n1 +"-"+ n2);
            Number n = new Number(n1,n2);
            sub.Add(n);
        }

        for (int i = 17; i <= 22; i++)
        {
            string ROW = l[i];
            string n1 = ROW.Substring(2,5); 
            string n2 = ROW.Substring(10,5);
            //Console.WriteLine(n1 +"-"+ n2);
            Number n = new Number(n1,n2);
            add.Add(n);
        }

        input = Substract(input, sub);
        input = AddNums(input, add);

        /*for (int i = 0; i < 5 ; i++)
        {
            Console.WriteLine(input[i].N1 +" "+ input[i].N2);
        }*/
        
        string result1 = "";
        string result2 = "";
        
        for (int i = 0; i < 5 ; i++)
        {
            result1 += input[i].N1;
            result2 += input[i].N2;
        }

        //Console.WriteLine(result1);
        //Console.WriteLine(result2);

        List<string> digits = new List<string>
        {
            " ~~~ |   |     |   | ~~~ ",// 0
            "         |         |     ",// 1
            " ~~~     | ~~~ |     ~~~ ",// 2
            " ~~~     | ~~~     | ~~~ ",// 3
            "     |   | ~~~     |     ",// 4
            " ~~~ |     ~~~     | ~~~ ",// 5
            " ~~~ |     ~~~ |   | ~~~ ",// 6
            " ~~~     |         |     ",// 7
            " ~~~ |   | ~~~ |   | ~~~ ",// 8
            " ~~~ |   | ~~~     | ~~~ " // 9
        };

        int d1 = digits.IndexOf(result1);
        int d2 = digits.IndexOf(result2);

        Console.WriteLine($"{d1}{d2}");
    }


    public static List<Number> Substract(List<Number> input, List<Number> sub)
    {
        for(int i = 0; i < 5; i++)
        {   
            input[i].N1 = SubsLine(input[i].N1,sub[i].N1);
            input[i].N2 = SubsLine(input[i].N2,sub[i].N2);
        }

        return input;
    }

    public static List<Number> AddNums(List<Number> input, List<Number> add)
    {
        for(int i = 0; i < 5; i++)
        {   
            input[i].N1 = AddLine(input[i].N1,add[i].N1);
            input[i].N2 = AddLine(input[i].N2,add[i].N2);
        }

        return input;
    }

    public static string AddLine(string input, string sub)
    {
        List<int> indexes = FindIndexesOfChar(sub, '|');
        List<int> indexes2 = FindIndexesOfChar(sub, '~');
        if(indexes.Count() > 0)
        {
            StringBuilder sb = new StringBuilder(input);
            foreach(int ind in indexes)            
                sb[ind] = '|';
            input = sb.ToString();
        }
        if(indexes2.Count() > 0)
        {
            StringBuilder sb = new StringBuilder(input);
            foreach(int ind in indexes2)            
                sb[ind] = '~';
            input = sb.ToString();
        }
        return input;
    }

    public static string SubsLine(string input, string sub)
    {
        List<int> indexes = FindIndexesOfChar(sub, '|');
        indexes.AddRange(FindIndexesOfChar(sub, '~'));
        if(indexes.Count() > 0)
        {
            StringBuilder sb = new StringBuilder(input);
            foreach(int ind in indexes)            
                sb[ind] = ' ';
            input = sb.ToString();
        }
        return input;
    }

    static List<int> FindIndexesOfChar(string input, char charToFind)
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == charToFind)
            {
                indices.Add(i);
            }
        }
        return indices;
    }
}

public class Number
{
    public Number(string N1, string N2)
    {
        this.N1 = N1;
        this.N2 = N2;
    }

    public string N1 { get; set; }
    public string N2 { get; set; }
}