using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();
        string[] words = word.Split(" ");
        Dic MyDictionary = new Dic(words);
        List<string> final = new List<string>();
        foreach(string w in words)        
            final.Add(MyDictionary.ListToUse.Where(x => x[0] == w[0]).FirstOrDefault());
        Console.WriteLine(string.Join(" ", final));
    }    
}

public class Dic
{
    public int MyProperty { get; set; }
    public List<string> ListToUse {get; set; }

    public Dic(string[] wordsKey)
    {
        int item = 0;
        int totalWords = wordsKey.Distinct().ToArray().Length;
        item = V1.Where(x => wordsKey.Distinct().Contains(x)).ToList().Count();        
        if(item == totalWords)
            this.ListToUse = V2;
        item = V2.Where(x => wordsKey.Distinct().Contains(x)).ToList().Count();        
        if(item == totalWords)
            this.ListToUse = V3;        
        item = V3.Where(x => wordsKey.Distinct().Contains(x)).ToList().Count();        
        if(item == totalWords)
            this.ListToUse = V4;
        item = V4.Where(x => wordsKey.Distinct().Contains(x)).ToList().Count();        
        if(item == totalWords)
            this.ListToUse = V1;
    }

    public readonly List<string> V1 = new List<string>
    {
        "Authority", "Bills", "Capture", "Destroy", "Englishmen", "Fractious", 
        "Galloping", "High", "Invariably", "Juggling", "Knights", "Loose", 
        "Managing", "Never", "Owners", "Play", "Queen", "Remarks", "Support", 
        "The", "Unless", "Vindictive", "When", "Xpeditiously", "Your", "Zigzag"
    };

    public readonly List<string> V2 = new List<string>
    {
        "Apples", "Butter", "Charlie", "Duff", "Edward", "Freddy", 
        "George", "Harry", "Ink", "Johnnie", "King", "London", 
        "Monkey", "Nuts", "Orange", "Pudding", "Queenie", "Robert", 
        "Sugar", "Tommy", "Uncle", "Vinegar", "Willie", "Xerxes", 
        "Yellow", "Zebra"
    };

    public readonly List<string> V3 = new List<string>
    {
        "Amsterdam", "Baltimore", "Casablanca", "Denmark", "Edison", "Florida", 
        "Gallipoli", "Havana", "Italia", "Jerusalem", "Kilogramme", "Liverpool", 
        "Madagascar", "New-York", "Oslo", "Paris", "Quebec", "Roma", "Santiago", 
        "Tripoli", "Uppsala", "Valencia", "Washington", "Xanthippe", "Yokohama", 
        "Zurich"
    };    

    public readonly List<string> V4 = new List<string>
    {
        "Alfa", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", 
        "Golf", "Hotel", "India", "Juliett", "Kilo", "Lima", 
        "Mike", "November", "Oscar", "Papa", "Quebec", "Romeo", 
        "Sierra", "Tango", "Uniform", "Victor", "Whiskey", 
        "X-ray", "Yankee", "Zulu"
    };
}