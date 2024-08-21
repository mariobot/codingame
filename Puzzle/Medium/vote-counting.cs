using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

class Solution
{
    static void Main(string[] args)
    {
        string[] inputs;
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        List<Candidate> candidates = new List<Candidate>();

        for (int i = 0; i < N; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            string personName = inputs[0];
            int nbVote = int.Parse(inputs[1]);
            Candidate candidate = new Candidate(personName, nbVote, 0, 0, 0);
            candidates.Add(candidate);
        }
        
        for (int i = 0; i < M; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            string voterName = inputs[0];
            string voteValue = inputs[1];

            var candidate = candidates.Where(x => string.Equals(x.Name, voterName,  StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if(candidate != null /*&& (voteValue == "Yes" || voteValue == "No")*/)
            {
                int total = candidate.YVotes + candidate.NVotes + candidate.WVotes + 1;

                if(total <= candidate.Max)
                {
                    if(voteValue == "Yes")
                        candidate.YVotes += 1;
                    else if(voteValue == "No")
                        candidate.NVotes += 1;
                    else
                        candidate.WVotes += 1;
                }
                else
                {
                    candidate.YVotes = 0;
                    candidate.NVotes = 0;
                    candidate.WVotes = 0;
                }
            }
            else if(candidate != null && (voteValue != "Yes" || voteValue != "No"))
            {
                int total = candidate.YVotes + candidate.NVotes + 1;

                if(total >= candidate.Max)
                {
                    candidate.YVotes = 0;
                    candidate.NVotes = 0;
                }
            }
        }
        
        Console.WriteLine(candidates.Select(x => x.YVotes).Sum()+" "+candidates.Select(x => x.NVotes).Sum());
        //Console.WriteLine(candidates.Where(x => x.Name == "Valérie").FirstOrDefault().YVotes);
    }
}

public class Candidate
{
    public Candidate(string Name, int Max, int YVotes, int NVotes, int WVotes)
    {
        this.Name = Name;
        this.Max = Max;
        this.YVotes = YVotes;
        this.NVotes = NVotes;
        this.WVotes = WVotes;
    }

    public string Name { get; set; }
    public int Max { get; set; }
    public int YVotes { get; set; }
    public int NVotes { get; set; }
    public int WVotes { get; set; }
}