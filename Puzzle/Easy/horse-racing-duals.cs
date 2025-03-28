using System;
using System.Linq;
using System.Collections.Generic;

int N = int.Parse(Console.ReadLine());
List<int> list = new List<int>();
for (int i = 0; i < N; i++)
{
    int pi = int.Parse(Console.ReadLine());
    list.Add(pi);
}

list = list.OrderBy(x=>x).ToList();
int min = list[1] - list[0];
for(int i = 0; i < N-1; i++){
    if(list[i+1] - list[i] < min)
        min = list[i+1] - list[i];
}

Console.WriteLine(min);