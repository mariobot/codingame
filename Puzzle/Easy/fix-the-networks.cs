using System;
using System.Linq;


int m = int.Parse(Console.ReadLine());
for (int i = 0; i < m; i++)
{
    string[] r = Console.ReadLine().Split("/");
    string[] ip = r[0].Split(".");
    int mask = int.Parse(r[1]);
    int totalZeros, totalMask;

    string binnaryIp = "";
    
    foreach(string val in ip)
        binnaryIp += Convert.ToString(int.Parse(val), 2).PadLeft(8, '0');

    var lastIndex = binnaryIp.LastIndexOf('1');

    totalZeros = 31 - lastIndex;
    totalMask = 32 - mask;

    if(binnaryIp.Count(x => x =='0') == 32)
    {
        totalZeros = 32;
        totalMask = 32 - mask;
    }

    if(totalZeros >= totalMask)
    {
        long totalConvinations = (long)Math.Pow((double)2, (double)totalMask);
        Console.WriteLine($"valid {totalConvinations}");
    }
    else
    {
        int newMask = 32 - totalZeros;
        long totalConvinations = (long)Math.Pow((double)2, (double)totalZeros);
        Console.WriteLine($"invalid {string.Join(".",ip)}/{newMask} {totalConvinations}");
    }
}