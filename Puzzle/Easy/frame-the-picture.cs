using System;
using System.Collections.Generic;

string framePattern = Console.ReadLine(); // the ASCII art pattern to use to frame the picture
string[] inputs = Console.ReadLine().Split(' ');
int h = int.Parse(inputs[0]); // the height of the picture
int w = int.Parse(inputs[1]); // the width  of the picture
List<string> pic = new List<string>();
for (int i = 0; i < h; i++)
{
    string line = Console.ReadLine(); // the ASCII art picture line by line
    pic.Add(line);
}

char[] c = framePattern.ToCharArray();

if(c.Length == 1)
{
    string l1 = new string(c[0], 2+w+2);
    Console.WriteLine(l1);
    string l2 = $"{c[0]}{new string(' ', 1+w+1)}{c[0]}";
    Console.WriteLine(l2);
    foreach(string s in pic)
    {
        string line = $"{c[0]} {s} {c[0]}";
        Console.WriteLine(line);
    }
    Console.WriteLine(l2);
    Console.WriteLine(l1);
}

if(c.Length == 2)
{
    string l1 = new string(c[0], 3+w+3);
    Console.WriteLine(l1);
    string l2 = $"{c[0]}{new string(c[1], 2+w+2)}{c[0]}";
    Console.WriteLine(l2);
    string l3 = $"{c[0]}{c[1]}{new string(' ', 1+w+1)}{c[1]}{c[0]}";
    Console.WriteLine(l3);
    foreach(string s in pic)
    {
        string line = $"{c[0]}{c[1]} {s} {c[1]}{c[0]}";
        Console.WriteLine(line);            
    }
    Console.WriteLine(l3);
    Console.WriteLine(l2);
    Console.WriteLine(l1);
}

if(c.Length == 3)
{
    string l1 = new string(c[0], 4+w+4);
    Console.WriteLine(l1);
    string l2 = $"{c[0]}{new string(c[1], 3+w+3)}{c[0]}";
    Console.WriteLine(l2);
    string l3 = $"{c[0]}{c[1]}{new string(c[2], 2+w+2)}{c[1]}{c[0]}";
    Console.WriteLine(l3);
    string l4 = $"{c[0]}{c[1]}{c[2]}{new string(' ', 1+w+1)}{c[2]}{c[1]}{c[0]}";
    Console.WriteLine(l4);
    foreach(string s in pic)
    {
        string line = $"{c[0]}{c[1]}{c[2]} {s} {c[2]}{c[1]}{c[0]}";
        Console.WriteLine(line);            
    }
    Console.WriteLine(l4);
    Console.WriteLine(l3);
    Console.WriteLine(l2);
    Console.WriteLine(l1);
}