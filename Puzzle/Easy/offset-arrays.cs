using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<MyIndex> myList = new List<MyIndex>();
        
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string Id = line.Substring(0,line.IndexOf('['));
            int Start = int.Parse(line.Substring(line.IndexOf('[') + 1, line.IndexOf("..") - line.IndexOf('[') -1));
            int End = int.Parse(line.Substring(line.IndexOf("..") + 2, line.IndexOf("]") - line.IndexOf("..") - 2));
            string[] values = line.Split("=")[1].Split(" ");
            MyIndex myIndex = new MyIndex(Id, Start, End, values);
            myList.Add(myIndex);
        }
        
        string x = Console.ReadLine();

        List<string> nestedInd = ExtractNestedInd(x);
        string idSearch = string.Empty;
        int? valSearch = null;
        int? result = null;

        for(int i = 1; i < nestedInd.Count(); i++)
        {
            if(i == 1)
            {
                idSearch = nestedInd[i];
                valSearch = int.Parse(nestedInd[0]);
            }
            else
            {
                idSearch = nestedInd[i];
                valSearch = result;
            }

            var item = myList.FirstOrDefault(x => x.Id == idSearch);        
            result = item.Values.Where(x => x.Item1 == valSearch).FirstOrDefault().Item2;
        }
        
        Console.WriteLine(result);
    }

    public static List<string> ExtractNestedInd(string input)
    {
        Stack<string> stack = new Stack<string>();
        List<string> result = new List<string>();
        string current = string.Empty;

        foreach (char c in input)
        {
            if (c == '[')
            {
                if (!string.IsNullOrEmpty(current))
                {
                    stack.Push(current);
                    current = string.Empty;
                }
            }
            else if (c == ']')
            {
                if (!string.IsNullOrEmpty(current))
                {
                    result.Add(current);
                    current = string.Empty;
                }
                if (stack.Count > 0)                
                    current = stack.Pop();                
            }
            else            
                current += c;            
        }

        string lastId = input.Substring(0,input.IndexOf('['));
        result.Add(lastId);
        return result;
    }
}

public class MyIndex
{
    public string Id { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public List<Tuple<int, int>> Values {get; set;}

    public MyIndex(string Id, int Start, int End, string[] values)
    {
        this.Id = Id;
        this.Start = Start;
        this.End = End;
        this.Values = new List<Tuple<int, int>>();

        int j = 1;
        for(int i = Start; i <= End; i++)
        {
            int valArray = int.Parse(values[j]);
            Tuple<int, int> val = new Tuple<int, int>(i, valArray);
            j += 1;
            this.Values.Add(val);
        }
    }
}