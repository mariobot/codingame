using System;
using System.Collections.Generic;
using System.Linq;

int R = int.Parse(Console.ReadLine());
int V = int.Parse(Console.ReadLine());
Int32 total = 0;
Int32 totalF = 0, time = 0;
int Iterator  = 0;
List<Int32> list = new List<Int32>();
List<Int32> RobberTime = new List<Int32>();

RobberTime.InsertRange(0, new int[R].ToList());

for (int i = 0; i < V; i++)
{
    string[] inputs = Console.ReadLine().Split(' ');
    int NumChars = int.Parse(inputs[0]);            
    int NumDigits = int.Parse(inputs[1]);
    int NumVoc = NumChars - NumDigits;

    int MultipleVocals = 1;
    for(int j = 1; j <= NumVoc; j++)
        MultipleVocals *= 5;

    int MultipleDigits = 1;
    for(int j = 1; j <= NumDigits; j++)
        MultipleDigits *= 10;

    total =  (MultipleVocals * MultipleDigits);
    list.Add(total);

    //Console.WriteLine($"{NumVoc} - {NumDigits}");
    //Console.WriteLine($"{MultipleVocals} - {MultipleDigits} = {total}");              
}

while (Iterator < V)
{
    int zeroIndex = RobberTime.IndexOf(0);

    if (zeroIndex >= 0)
    {
        RobberTime[zeroIndex] = list[Iterator];
        Iterator++;
    }
    else
    {
        RobberTime.Sort();
        time = RobberTime.First();
        totalF += time;
        RobberTime = RobberTime.Select(x => x - time).ToList();
    }
}

Console.WriteLine(totalF+RobberTime.Max());