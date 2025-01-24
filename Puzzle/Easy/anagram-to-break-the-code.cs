using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

    string word = Console.ReadLine();
    StringBuilder line = new StringBuilder(Console.ReadLine());        
    
    for(int i = 0; i < line.Length; i++)        
        if(i >= 1 && i < line.Length-1)
            if(char.IsLetter(line[i-1])&&char.IsPunctuation(line[i])&&char.IsLetter(line[i+1]))
                line[i] = ' ';        
    
    List<string> list = line.ToString().ToLower().Split(" ").ToList();
    string anagramWord = CheckAnagram(list,word);

    list = list.Where(x => !char.IsPunctuation((char)x[0])).ToList();

    int a = list.IndexOf(anagramWord);
    int b = list.Count-1  - list.IndexOf(anagramWord);

    if(a == -1)        
        Console.WriteLine("IMPOSSIBLE");

    List<string> la = list.GetRange(0, a);
    List<string> lb = list.GetRange(a+1, b);

    int c = 0;
    int d = 0;

    foreach(string s in la)        
        c += s.ToCharArray().Count(x => char.IsLetter(x));

    foreach(string s in lb)
        d += s.ToCharArray().Count(x => char.IsLetter(x));

    a = RigthVal(a); 
    b = RigthVal(b); 
    c = RigthVal(c); 
    d = RigthVal(d); 

    Console.WriteLine($"{a}.{b}.{c}.{d}");
}

public static string CheckAnagram(List<string> list, string word)
{
    foreach(string s in list)
    {
        int matchCount = 0;
        string wordToCheck = string.Join("",s.Where(x => x != '.'));
        
        foreach(char c in wordToCheck)            
                if(word.Contains(c))
                matchCount += 1;
        
        if(matchCount == wordToCheck.Length && matchCount == word.Length && wordToCheck != word)
            return s;
    }

    return "";
}

public static int RigthVal(int val)
{
    while (val >= 10)        
        val %= 10;
    return val;
}