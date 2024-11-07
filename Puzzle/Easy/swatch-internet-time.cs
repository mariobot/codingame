using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        string rawtime = Console.ReadLine();
        string UTC = rawtime.Split(" ")[1];
        char sign = UTC.Replace("UTC","").FirstOrDefault();
        int UTCH = Convert.ToInt16(UTC.Replace("UTC","").Replace("+","").Replace("-","").Split(":")[0]);
        int UTCM = Convert.ToInt16(UTC.Replace("UTC","").Replace("+","").Replace("-","").Split(":")[1]);

        DateTime d = DateTime.Parse(rawtime.Split(" ")[0]);
        DateTime res = new DateTime();

        if(sign == '+' && UTCH == 1 && UTCM == 0)        
            res = d;        
        else if(sign == '+')        
            res = d.AddHours(-(UTCH-1)).AddMinutes(-UTCM);        
        else if(sign == '-')        
            res = d.AddHours(+(UTCH+1)).AddMinutes(+UTCM);
        
        float total = (float)(3600 * (float)res.Hour + 60 * (float)res.Minute + (float)res.Second)/(float)86.4;

        Console.WriteLine($"@{total.ToString("0.00")}");
    }
}