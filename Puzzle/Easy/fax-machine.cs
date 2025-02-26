using System;
using System.Linq;
using System.Collections.Generic;


int W = int.Parse(Console.ReadLine());
int H = int.Parse(Console.ReadLine());        
List<int> values = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList();

int Total = W*H;
string result = "|";
char symbol = '*';
int changeIn = values[0];

for(int i = 1; i < Total+1 ; i ++)
{
    if(i == changeIn + 1 && changeIn <= Total)
    {
        symbol = symbol == '*' ? ' ' : '*';

        values = NextValue(values);

        if(values != null)                
            changeIn = i + values[0] -1;
    }

    if(i != 1)
    {
        if(i % W == 1)
            result += "\n|";

        result += symbol;

        if(i % W == 0)
            result += "|";
    }
    else
    {
        result += symbol;
    }
}

Console.WriteLine(result);


public static List<int> NextValue(List<int> values)
{
    values.Remove(values.First());
    return values;
}