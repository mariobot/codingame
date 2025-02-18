using System;
using System.Collections.Generic;

long P = long.Parse(Console.ReadLine());
int length = 0;
long Pt = P;
string C = Console.ReadLine();
List<char> list = new List<char>();
bool isFirst = true;
length = C.Length;

while (Pt > 0)
{
    long remainder = Pt % length;
    if(isFirst)
    {
        list.Add(C[(int)remainder]);
        isFirst = false;
    }
    else
    {
        if (((int)remainder-1) == -1){
            Pt -= length;
        }   
        else
            list.Add(C[(int)remainder-1]);
    }

    Pt /= length;
}

Console.WriteLine(string.Join("",list));