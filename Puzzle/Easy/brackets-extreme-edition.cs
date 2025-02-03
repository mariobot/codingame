using System;
using System.Linq;
using System.Collections.Generic;


string line = Console.ReadLine();
Dictionary<char, int> elements = new Dictionary<char, int>();
string init = "([{)]}";
bool contain = false;

foreach(char c in init.ToCharArray())
{
    elements.Add(c,0);
}

foreach(char c in line.ToCharArray())
{
    if(c == '(' || c == '[' || c == '{')
    {
        elements[c] += 1;
    }
    if(c == ')' || c == ']' || c == '}')
    {
        elements[c] += 1;
    }
}

int ch1 = elements['(']-elements[')'];
int ch2 = elements['[']-elements[']'];
int ch3 = elements['{']-elements['}'];

foreach(char c in init.ToCharArray())
{
    if(init.Contains(c))
        contain = true;
}

if((line.FirstOrDefault() == ']' && line.LastOrDefault() == '[') || line == "{(})" || (line.FirstOrDefault() == ')' && line.LastOrDefault() == '('))
    contain = false;

if(ch1 == 0 && ch2 == 0 && ch3 == 0 && contain)
    Console.WriteLine("true");
else
    Console.WriteLine("false");