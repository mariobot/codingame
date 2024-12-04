using System;
using System.Collections.Generic;

string[] inputs;
int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
Dictionary<string,List<bool>> list = new Dictionary<string, List<bool>>();

for (int i = 0; i < n; i++)
{
    inputs = Console.ReadLine().Split(' ');
    string inputName = inputs[0];
    string inputSignal = inputs[1];
    List<bool> lb = ConvertBool(inputSignal);            
    list.Add(inputName,lb);
}

for (int i = 0; i < m; i++)
{
    inputs = Console.ReadLine().Split(' ');
    string outputName = inputs[0];
    string type = inputs[1];
    string inputName1 = inputs[2];
    string inputName2 = inputs[3];

    List<bool> result = Compute(type, list[inputName1], list[inputName2]);
    Console.WriteLine($"{outputName} {ConvertSignal(result)}");
}
    

public static List<bool> Compute(string type, List<bool> input1, List<bool> input2)
{
    List<bool> lb = new List<bool>();
    
    for(int i = 0; i < input1.Count; i++)
    {
        lb.Add(LogicalOp(input1[i], input2[i], type));
    }
    
    return lb;
}

public static bool LogicalOp(bool v1, bool v2, string type)
{
    if(type == "AND")
        return v1 && v2;
    else if(type == "OR")
        return v1 || v2;
    else if(type == "XOR")
        return v1 ^ v2;
    else if(type == "NAND")
        return !(v1 && v2);
    else if(type == "NOR")
        return !(v1 || v2);
    else 
        return !(v1 ^ v2);
}

public static List<bool> ConvertBool(string s)
{
    List<bool> lb = new List<bool>();
    foreach(char c in s.ToCharArray())
    {
        if(c == '-')
            lb.Add(true);
        else
            lb.Add(false);
    }
    return lb;
}

public static string ConvertSignal(List<bool> lb)
{
    string result = "";
    foreach(bool b in lb)
    {
        if(b == true)
            result+= "-";
        else
            result += "_";
    }

    return result;
}