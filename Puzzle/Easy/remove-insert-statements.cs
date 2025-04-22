using System;
using System.Linq;
using System.Collections.Generic;

int N = int.Parse(Console.ReadLine());        
List<Line> lines = new List<Line>();

for (int i = 0; i < N; i++)
{
    string FNAME = Console.ReadLine();
    Line l = new Line(){
        exept = false,
        line = FNAME
    };
    lines.Add(l);
}

lines = CheckLines(lines);

bool prev = false;

foreach(Line info in lines.Where(x => !x.exept))
{
    int count = info.line.ToUpper().Split(' ').Where(x => x.Contains("INSERT")).Count();

    for(int i = 0; i < count; i++)
    {
        int ind = info.line.ToUpper().IndexOf("INSERT ");
        
        if(ind >= 0)
        {
            string line = info.line.Substring(ind);
            string toDelete = ""        ;

            int foundComa = line.IndexOf(";");
            if(foundComa != -1)
            {
                toDelete = line.Substring(0,line.IndexOf(";")+1);
                info.line = info.line.Replace(toDelete, "");
            }
            else
            {
                info.line = string.Empty;
                prev = true;
            }
        }
    }

    if(prev)
    {
        int foundComa = info.line.IndexOf(";");
        if(foundComa != -1)
        {
            info.line = string.Empty;
            prev = false;
        }
        else                
            info.line = string.Empty;
    }
}

// Remove empry lines
lines = lines.Where(x => x.line != string.Empty).ToList();

foreach(Line l in lines)
    Console.WriteLine(l.line);

public class Line
{
    public bool exept { get; set; } = false;
    public string line { get; set; }
}

public static List<Line> CheckLines(List<Line> lines)
{
    bool inBeginSentence = false;

    foreach(Line l in lines)
    {
        if(l.line.StartsWith("begin"))
        {
            inBeginSentence = true;
            l.exept = true;
        }
        
        if(inBeginSentence)
        {
            l.exept = true;
        }

        if(l.line.StartsWith("end") && inBeginSentence)
        {
            inBeginSentence = false;
            l.exept = true;
        }
        
        if(l.line.StartsWith("--"))
        {
            inBeginSentence = false;
            l.exept = true;
        }
    }

    return lines;
}