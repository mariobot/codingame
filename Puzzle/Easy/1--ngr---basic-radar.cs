using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<Information> list = new List<Information>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string plate = inputs[0];
            string radarname = inputs[1];
            long timestamp = long.Parse(inputs[2]);

            var existRecord = list.FirstOrDefault(x => x.Plate == plate);

            if(existRecord == null)
            {
                Information inf = new Information(plate, radarname, timestamp);
                list.Add(inf);
            }
            else            
                existRecord.AddRegister(radarname, timestamp);
        }

        list = list.Where(x => x.CalcDiff() > 130).DistinctBy(x => x.Plate).OrderBy(x => x.Plate).ToList();

        foreach(Information inf in list)
            Console.WriteLine($"{inf.Plate} {inf.CalcDiff()}");
    }
}

public class Information
{
    public string Plate { get; set; }
    public long First { get; set; }
    public long Second { get; set; }

    public Information(string plate, string radarname, long timespan)
    {
        this.Plate = plate;

        if(radarname == "A21-42")
            this.First = timespan;
        else
            this.Second = timespan;
    }

    public void AddRegister(string radarname, long timespan)
    {
        if(radarname == "A21-42")
            this.First = timespan;
        else
            this.Second = timespan;
    }

    public int CalcDiff()
    {
        double timeHours = (Second - First) / (1000.0 * 60 * 60);
        double speed = 13 / timeHours;
        return (int)speed;
    }
}