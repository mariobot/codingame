using System;
using System.Linq;
using System.Collections.Generic;

int N = int.Parse(Console.ReadLine());
List<string> inv = new List<string>();
for (int i = 0; i < N; i++)
{
    string ISBN = Console.ReadLine();

    if(ISBN.Length == 10 && ISBN.Substring(0,9).All(char.IsDigit))
    {
        int sum = 0;
        int mult = 10;
        
        for(int j = 0; j < ISBN.Length - 1 ; j++)
        {
            sum += int.Parse(ISBN[j].ToString()) * mult;
            mult -= 1;
        }

        int comp = sum % 11;
        int controlNumber = 0;
        if(comp == 0)
            controlNumber = 0;
        else
            controlNumber = 11 - comp;

        if(controlNumber >= 10)
        {
            if(ISBN[9] != 'X')
                inv.Add(ISBN);
        }
        else
        {
            if(ISBN[9].ToString() != controlNumber.ToString())                
                inv.Add(ISBN);
        }
    }
    else if(ISBN.Length == 13 && ISBN.All(char.IsDigit))
    {
        int sum = 0;
        int mult = 1;
        for(int j = 0; j < ISBN.Length - 1 ; j++)
        {
            sum += int.Parse(ISBN[j].ToString()) * mult;
            if(mult == 1)
                mult = 3;
            else
                mult = 1;
        }

        int comp = sum % 10;
        int controlNumber = 0;
        if(comp == 0)
            controlNumber = 0;
        else
            controlNumber = 10 - comp;

        if(ISBN[12].ToString() != controlNumber.ToString())                
            inv.Add(ISBN);
    }
    else
        inv.Add(ISBN);
}

Console.WriteLine($"{inv.Count()} invalid:");
foreach(string val in inv)        
    Console.WriteLine(val);