using System;
using System.Text;

class Solution
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string units = string.Empty;
        string decimals = string.Empty;

        for(int i = 0; i < text.Length; i++)
        {
            if(text[i] != ',' && text[i] != '.' && text[i] != 'x')
            {
                if(i < 11)
                    units += text[i];
                else
                    decimals += text[i];
            }
        }

        if(string.IsNullOrEmpty(units) && string.IsNullOrEmpty(decimals))
            Console.WriteLine(text);

        decimal value = decimal.Parse($"{units}.{decimals}")/2;

        if(value != Math.Floor(value))
        {
            units = value.ToString().Split(".")[0];
            decimals = value.ToString().Split(".")[1];
        }            
        else
            units = value.ToString().Split(".")[0];

        int tu = 9 - units.Length;
        
        if(tu > 0)
        {
            if (units == "0")
                units = new string('x',9);
            else
                units = new string('x',tu) + units;
        }
            

        int td = 6 - decimals.Length;
        if(td > 0)
            decimals = decimals + new string('x',td);
        
        StringBuilder sbU = new StringBuilder(units);
        StringBuilder sbD = new StringBuilder(decimals);
        sbU.Insert(3,",");
        sbU.Insert(7,",");
        sbU.Insert(11,".");
        sbD.Insert(3,".");

        string final = sbU.ToString() + sbD.ToString();

        Console.WriteLine(final);
    }
}