using System;
using System.Linq;

class S
{
    static void Main(string[] args)
    {
        long r1 = long.Parse(Console.ReadLine());
        long r2 = long.Parse(Console.ReadLine());

        bool flag = true;
        bool init = true;
        long final = 0;

        long v1 = 0;
        long v2 = 0;

        while(flag)
        {
            if(init)
            {
                v1 = r1;
                v2 = r2;
                init = false;
            }

            if(v1 < v2)
            {
                v1 = DigitalR(v1);
            }
            else
                v2 = DigitalR(v2);

            if(v1 == v2)
            {
                final = v1;
                flag = false;
            }
        }

        Console.WriteLine(final);
    }

    public static long DigitalR(long value)
    {
        return value +  value.ToString().ToCharArray().Sum(c => long.Parse(c.ToString()));
    }
}