using System;
using System.Collections.Generic;
using System.Linq;

class LeaderboardUpdater
{
    static void Main()
    {
        List<int> scores = new List<int>();

        Console.WriteLine("Enter 10 player scores:");

        while (scores.Count < 10)
        {
            Console.Write($"Score {scores.Count + 1}: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int score))
            {
                scores.Add(score);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        scores.Sort((a, b) => b.CompareTo(a));

        Console.WriteLine("\nLeaderboard BEFORE:");
        DisplayLeaderboard(scores);

        int newScore;
        while (true)
        {
            Console.Write("\nEnter new player's score: ");
            if (int.TryParse(Console.ReadLine(), out newScore))
                break;
            else
                Console.WriteLine("Invalid input.");
        }

        int insertIndex = scores.FindIndex(s => newScore >= s);
        if (insertIndex == -1)
            scores.Add(newScore); 
        else
            scores.Insert(insertIndex, newScore); 

        Console.WriteLine("\nLeaderboard AFTER:");
        DisplayLeaderboard(scores);
    }

    static void DisplayLeaderboard(List<int> scores)
    {
        for (int i = 0; i < scores.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scores[i]}");
        }
    }
}
