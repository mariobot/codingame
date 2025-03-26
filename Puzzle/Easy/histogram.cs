using System;
using System.Collections.Generic;
using System.Linq;

string S = Console.ReadLine();

string dic = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
int numLet = 0;
Dictionary<char, int> letters = new Dictionary<char, int>();
foreach(char c in dic.ToCharArray())        
    letters.Add(c,0);

foreach(char c in S.ToUpper().ToCharArray())
{
    if(char.IsLetter(c))
    {
        numLet += 1;
        letters[c] += 1;
    }
}

string lastLine = "";

for(int j = 0; j < letters.Count(); j++)
{
    var let = letters.ElementAt(j);

    decimal d = 0;
    if(let.Value != 0)
        d = (100 / (decimal)numLet) * let.Value;
    
    //Console.WriteLine($"{let.Key} {let.Value} {string.Format("{0:F2}%",d)} ");

    int val = (int)Math.Round(d);

    if(let.Key == 'A')
    {
        if(val > 0)                
            Console.WriteLine($"  +{new string('-',val)}+");
        else
            Console.WriteLine($"  +");
    }
        
    
    if(val > 0)
        Console.WriteLine($"{let.Key} |{new string(' ',val)}|{string.Format("{0:F2}%",d)}");
    else
        Console.WriteLine($"{let.Key} |{string.Format("{0:F2}%",d)}");
    
    if(j == letters.Count()-1)
    {
        if(let.Value > 0)
        {
            lastLine = $"  +{new string('-',val)}+";
        }                    
        else
        {
            lastLine = $"  +";
        }
    }
    else
    {
        var next = letters.ElementAt(j+1);

        decimal nextValue = 0;
        if(next.Value != 0)
            nextValue = (100 / (decimal)numLet) * next.Value;
        
        nextValue = (int)Math.Round(nextValue);

        //Console.WriteLine(let.Key+"-"+val +"-"+ nextValue);

        if(nextValue > val)
        {   
            if(val == 0)
            {
                lastLine = $"  +{new string('-',(int)nextValue)}+";
            }
            else
            {
                decimal diff = nextValue - val;
                lastLine = $"  +{new string('-',val)}+{new string('-',(int)diff-1)}+";
            }
        }                
        else if(val > nextValue)
        {
            if(nextValue == 0)
            {
                lastLine = $"  +{new string('-',(int)val)}+";
            }
            else
            {
                decimal diff2 = val - nextValue;
                lastLine = $"  +{new string('-',(int)nextValue)}+{new string('-',(int)diff2-1)}+";
            }
        }
        else if(val == nextValue && val > 0)
        {
            lastLine = $"  +{new string('-',(int)val)}+";
        }
        else if(val == 0 && nextValue == 0)
        {
            lastLine = $"  +";
        }
    }

    Console.WriteLine(lastLine);
}