using System;
using System.Linq;
using System.Collections.Generic;


int N = int.Parse(Console.ReadLine());
var list = new List<(string transaction, int value)>();

for (int i = 0; i < N; i++)
{
    string transaction = Console.ReadLine();
    int value = transaction.FirstOrDefault(c => c != '0' && char.IsDigit(c)) - '0';
    if (value > 0)
    {
        list.Add((transaction, value));
    }
}

var percentages = new Dictionary<int, double>
{
    { 1, 30.1 },
    { 2, 17.6 },
    { 3, 12.5 },
    { 4, 9.7 },
    { 5, 7.9 },
    { 6, 6.7 },
    { 7, 5.8 },
    { 8, 5.1 },
    { 9, 4.6 }
};      

double total = list.Count;
int state = percentages.Keys.Count(i =>
{
    double countV = list.Count(x => x.value == i);
    double p = countV / total * 100;
    return p < percentages[i] - 10 || p > percentages[i] + 10;
});

Console.WriteLine(state > 0 ? "true" : "false");