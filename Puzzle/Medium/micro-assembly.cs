using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int a = int.Parse(inputs[0]);
        int b = int.Parse(inputs[1]);
        int c = int.Parse(inputs[2]);
        int d = int.Parse(inputs[3]);
        
        Dictionary<string,int> values = new Dictionary<string,int>();
        values.Add("a",a);
        values.Add("b",b);
        values.Add("c",c);
        values.Add("d",d);

        int n = int.Parse(Console.ReadLine());
        List<Operation> list = new List<Operation>();
        for (int i = 0; i < n; i++)
        {
            string[] ins = Console.ReadLine().Split(" ");
            Operation op = new Operation();

            if(ins.Length == 3)
            {
                op.Indication = ins[0];
                op.p1 = ins[1];
                op.p2 = ins[2];
            }
            else
            {
                op.Indication = ins[0];
                op.p1 = ins[1];
                op.p2 = ins[2];
                op.p3 = ins[3];
            }

            list.Add(op);
        }

        for(int i = 0; i < list.Count(); i++)
        {
            Operation op = list[i];

            if(op.Indication == "MOV")            
            {
                if(!int.TryParse(op.p2, out int valP2)){
                    valP2 = values[op.p2];
                }

                values[op.p1] = valP2;
            }

            if(op.Indication == "ADD")            
            {
                if(!int.TryParse(op.p2, out int valP2)){
                    valP2 = values[op.p2];
                }                

                if(!int.TryParse(op.p3, out int valP3)){
                    valP3 = values[op.p3];
                }

                values[op.p1] = valP2 + valP3;
            }
            
            if(op.Indication == "SUB")            
            {
                if(!int.TryParse(op.p2, out int valP2)){
                    valP2 = values[op.p2];
                }

                if(!int.TryParse(op.p3, out int valP3)){
                    valP3 = values[op.p3];
                }

                values[op.p1] = valP2 - valP3;
            }

            if(op.Indication == "JNE")
            {
                int.TryParse(op.p1, out int valRow);
                int.TryParse(op.p3, out int valToCheck);                

                if(values[op.p2] == valToCheck){}
                else
                {
                    i = valRow-1;
                }
            }
        }

        Console.WriteLine($"{values["a"]} {values["b"]} {values["c"]} {values["d"]}");
    }

    public class Operation
    {
        public string Indication { get; set; }
        public string p1 { get; set; }
        public string p2 { get; set; }
        public string p3 { get; set; }
    }
}