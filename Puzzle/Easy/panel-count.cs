using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int P = int.Parse(Console.ReadLine());
        List<string> filters = new List<string>();
        List<string[]> lines = new List<string[]>();
        List<List<Operation>> formulas = new List<List<Operation>>();

        for (int i = 0; i < P; i++)
        {
            string property = Console.ReadLine();
            filters.Add(property);
        }
        
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string[] l = Console.ReadLine().Split(" ");
            lines.Add(l);
        }
        
        int F = int.Parse(Console.ReadLine());
        for (int i = 0; i < F; i++)
        {
            string f = Console.ReadLine();
            List<Operation> list = new List<Operation>();

            if(f.Contains(" AND "))
            {
                string[] sentence = f.Split(" AND ");
                foreach(string w in sentence)                
                    list.Add(FormatOperation(w));
            }
            else            
                list.Add(FormatOperation(f));
            
            formulas.Add(list);            
        }

        foreach(List<Operation> Os in formulas)
        {
            var linesCopy = lines;
            foreach(Operation o in Os)            
                linesCopy = Filter(linesCopy, o.Value, filters.IndexOf(o.Filter)+1);                            
            Console.WriteLine(linesCopy.Count());
        }
    }

    public static List<string[]> Filter(List<string[]> list, string value, int i = 0)
    {
        List<string[]> result = list.Where(x => x[i] == value).ToList();
        return result;
    }

    public static Operation FormatOperation(string line)
    {
        int ind = line.IndexOf('=');
        string filter = line.Substring(0,ind);
        string value = line.Substring(ind+1,line.Length-(ind+1));

        Operation op = new Operation(){
            Filter = filter,
            Value = value
        };

        return op;
    }

    public class Operation
    {
        public string Filter { get; set; }
        public string Value { get; set; }
    }
}