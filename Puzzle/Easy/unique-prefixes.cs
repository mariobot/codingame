using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<string> list = new List<string>();
        
        for (int i = 0; i < N; i++)
        {
            string word = Console.ReadLine();
            list.Add(word);
        }
        
        for (int i = 0; i < N; i++)
            list = SearchRecursive(list, i, 1, list[i]);

        foreach(string s in list)
            Console.WriteLine(s);
    }

    public static List<string> SearchRecursive(List<string> list, int index, int chars, string word)
    {
        if(list.Where(x => x != word && x.Length >= chars && word.Length > chars  && x.Substring(0, chars) == word.Substring(0, chars)).Count() == 0)
        {
            list[index] = word.Substring(0, chars);
            return list;
        }   
        else
        {
            chars += 1;
            list = SearchRecursive(list, index, chars, word);
            return list;
        }
    }
}