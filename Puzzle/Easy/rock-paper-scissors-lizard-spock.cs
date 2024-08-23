using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<Player> players =  new List<Player>();
        List<Player> winners = new List<Player>();
        
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int numplayer = int.Parse(inputs[0]);
            string singleplayer = inputs[1];
            Player player = new Player(numplayer, Convert.ToChar(singleplayer));
            players.Add(player);
        }

        int round = N;
        while(round >= 2)
        {
            winners = new List<Player>();
            
            for (int i = 0; i < round; i = i+2)
            {
                Player winner = Tournament.DetermineWinner(players[i], players[i+1]);
                winners.Add(winner);
            }

            if(winners.Count() == 1)            
                break;

            players = winners;
            
            round = round / 2;
        }

        Console.WriteLine(winners.FirstOrDefault().Number);
        Console.WriteLine(string.Join(" ", winners.FirstOrDefault().Participants));
    }
}

class Player
{
    public int Number { get; }
    public char Sign { get; }
    public List<int> Participants { set; get; } = new List<int>();

    public Player(int number, char sign)
    {
        Number = number;
        Sign = sign;
    }

    public void AddParticipant(int playerNumber)
    {
        Participants.Add(playerNumber);
    }
}

class Tournament
{
    private static readonly Dictionary<char, List<char>> defeatMap = new Dictionary<char, List<char>>
    {
        { 'R', new List<char> { 'L', 'C' } }, // Rock crushes Lizard, Rock crushes Scissors
        { 'P', new List<char> { 'R', 'S' } }, // Paper covers Rock, Paper disproves Spock
        { 'C', new List<char> { 'P', 'L' } }, // Scissors cuts Paper, Scissors decapitates Lizard
        { 'L', new List<char> { 'S', 'P' } }, // Lizard poisons Spock, Lizard eats Paper
        { 'S', new List<char> { 'C', 'R' } }  // Spock smashes Scissors, Spock vaporizes Rock
    };

    public static Player DetermineWinner(Player player1, Player player2)
    {
        if (player1.Sign == player2.Sign)
        {
            // If it's a tie, the player with the lower number wins
            if(player1.Number < player2.Number)
            {
                player1.AddParticipant(player2.Number);
                return player1;
            }
            else
            {
                player2.AddParticipant(player1.Number);
                return player2;
            }
        }

        if (defeatMap[player1.Sign].Contains(player2.Sign))
        {
            player1.AddParticipant(player2.Number);
            return player1; // player1 wins

        }
        else
        {
            player2.AddParticipant(player1.Number);
            return player2; // player2 wins
        }
    }
}