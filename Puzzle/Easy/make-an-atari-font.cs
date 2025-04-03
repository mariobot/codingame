using System;
using System.Linq;
using System.Collections.Generic;

string aWord = Console.ReadLine();

Dictionary<char, ulong> dic = new Dictionary<char, ulong>
{
    {'A', 0x1818243C42420000},
    {'B', 0x7844784444780000},
    {'C', 0x3844808044380000},
    {'D', 0x7844444444780000},
    {'E', 0x7C407840407C0000},
    {'F', 0x7C40784040400000},
    {'G', 0x3844809C44380000},
    {'H', 0x42427E4242420000},
    {'I', 0x3E080808083E0000},
    {'J', 0x1C04040444380000},
    {'K', 0x4448507048440000},
    {'L', 0x40404040407E0000},
    {'M', 0x4163554941410000},
    {'N', 0x4262524A46420000},
    {'O', 0x1C222222221C0000},
    {'P', 0x7844784040400000},
    {'Q', 0x1C222222221C0200},
    {'R', 0x7844785048440000},
    {'S', 0x1C22100C221C0000},
    {'T', 0x7F08080808080000},
    {'U', 0x42424242423C0000},
    {'V', 0x8142422424180000},
    {'W', 0x4141495563410000},
    {'X', 0x4224181824420000},
    {'Y', 0x4122140808080000},
    {'Z', 0x7E040810207E0000}
};

Dictionary<char, List<string>> map = ConverMap(dic);

List<string> result = ProcessWord(aWord, map);

PrintResult(result);


public static Dictionary<char, List<string>> ConverMap(Dictionary<char, ulong> dic)
{
    Dictionary<char, List<string>> map = new Dictionary<char, List<string>>();

    foreach(KeyValuePair<char,ulong> key in dic)
    {
        string b = Convert.ToString((long)key.Value, 2).PadLeft(64, '0');
        b = b.Replace("0"," ").Replace("1","X");
        List<string> ml = new List<string>();
        for(int i = 0; i < b.Length; i +=8)                
            ml.Add(b.Substring(i,8));            
        map.Add(key.Key,ml);
    }

    return map;
}

public static List<string> ProcessWord(string word, Dictionary<char, List<string>> map)
{
    List<string> result = new List<string>{ string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty};

    foreach(char c in word.ToCharArray())
    {
        List<string> letter = map[c];

        for(int i = 0; i < result.Count(); i ++)
        {
            result[i] = result[i]+letter[i];
        }
    }

    return result;
}

public static void PrintResult(List<string> result)
{
    for(int i = 0; i < result.Count(); i++)
    {
        if(i != result.Count()-1)
            Console.WriteLine(TrimTrailingSpaces(result[i]));            
        else
            Console.Write(TrimTrailingSpaces(result[i])); 
    }
}

static string TrimTrailingSpaces(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        return input;
    }

    int endIndex = input.Length - 1;
    while (endIndex >= 0 && char.IsWhiteSpace(input[endIndex]))
    {
        endIndex--;
    }

    return input.Substring(0, endIndex + 1);
}