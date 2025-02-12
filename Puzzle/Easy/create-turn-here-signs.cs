using System;
using System.Text;

string input = Console.ReadLine();
string[] inDic = input.Split(' ');

string direction = inDic[0];
string arrowLine = "";
int numArrows = int.Parse(inDic[1]);
int heigthArrows = int.Parse(inDic[2]);
int strokeArrows = int.Parse(inDic[3]);
int spaceBetArrows = int.Parse(inDic[4]);
int additionalIndent = int.Parse(inDic[5]);
decimal maxLine = Math.Floor((decimal)heigthArrows/2+1);
string identationString = new string(' ',additionalIndent);
string spaceba = new string(' ', spaceBetArrows);
int sumLine = 0;


if(direction == "right")
    arrowLine = new string('>',strokeArrows);
else
{
    sumLine = (int)maxLine-1;
    arrowLine = new string('<',strokeArrows);
}

for(int i = 1; i <= heigthArrows; i++)
{
    string l = StringExtensions.Repeat(arrowLine+spaceba,numArrows);
    l = l.Remove(l.Length-spaceBetArrows);

    if(direction == "right")
    {
        if( i < maxLine)
        {
            if(sumLine > 0)
            {
                Console.WriteLine(StringExtensions.Repeat(identationString,sumLine)+l);
            }
            else
                Console.WriteLine(l);

            sumLine++;
        }
        else
        {
            if(sumLine == heigthArrows)                    
                Console.WriteLine(l);
            else
                Console.WriteLine(StringExtensions.Repeat(identationString,sumLine)+l);

            sumLine--;
        }
    }
    else
    {
        if( i < maxLine)
        {
            if(sumLine > 0)
            {
                Console.WriteLine(StringExtensions.Repeat(identationString,sumLine)+l);
            }
            else
                Console.WriteLine(l);
            
            sumLine--;
        }
        else
        {
            if(sumLine == heigthArrows)                    
                Console.WriteLine(l);
            else
                Console.WriteLine(StringExtensions.Repeat(identationString,sumLine)+l);

            sumLine++;
        }
    }
}

public static class StringExtensions
{
    public static string Repeat(this string s, int n) => new StringBuilder(s.Length * n).Insert(0, s, n).ToString();
}