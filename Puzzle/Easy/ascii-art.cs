using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine();
        char[] word = T.ToLower().ToCharArray();
        char[] dic = "abcdefghijklmnopqrstuvwxyz?".ToCharArray();
        List<CharInfo> cInfo = new List<CharInfo>();
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();

            int index = 0;

            if(i == 0)
            {
                foreach(char c in dic)
                {
                    string extracted = ROW.Substring(index, L);
                    var mm = new CharInfo() 
                    { 
                        OriginalChar = c, Lines = new List<string>(),
                    };
                    mm.Lines.Add(extracted);
                    cInfo.Add(mm);
                    index += L;
                }
            }
            else
            {
                foreach(char c in dic)
                {
                    string extracted = ROW.Substring(index, L);                    
                    var mm = cInfo.Where(x => x.OriginalChar == c).FirstOrDefault();
                    mm.Lines.Add(extracted);
                    index += L;
                }
            }
        }

        for(int i = 0; i < H ; i++)
        {
            string row = "";
            foreach(char w in word)
            {
                if(dic.Contains(w))
                {
                    var info = cInfo.Where(x => x.OriginalChar == w).FirstOrDefault();
                    row += info.Lines[i];
                }
                else
                {
                    var info = cInfo.Where(x => x.OriginalChar == '?').FirstOrDefault();
                    row += info.Lines[i];
                }
            }

            Console.WriteLine(row);
        }
        
    }

    public class CharInfo
    {
        public char OriginalChar { get; set; }
        public List<string> Lines {get; set; } = new List<string>();
    }
}