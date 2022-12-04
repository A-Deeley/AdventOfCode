using AdventHelper;
using System.Diagnostics;

namespace AdventOfCode2
{
    public class Program
    {
        const int ABCAdjust = 65;
        const int XYZAdjust = 88;
        struct RPSPair
        {
            public RPSPair(string p1, string p2)
            {
                P1 = p1[0];
                P2 = p2[0];
            }

            public int P1 { get; set; }
            public int P2 { get; set; }
        }

        public static async Task Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<string> rockPaperScissorPairs = await PuzzleInputManager.LoadPuzzleText("Inputs/PuzzleInput2.txt");
            List<RPSPair> RPSPairs = new(rockPaperScissorPairs.Select(pair =>
            {
                var splitPair = pair.Split(' ');
                return new RPSPair(splitPair[0], splitPair[1]);
            }));

            Console.WriteLine("\n\nDay 2:");
            Console.WriteLine("======Part 1======");
            Console.WriteLine($"Total score of my guide was: {Part1(RPSPairs)}");
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
            Console.WriteLine("\n======Part 2======");
            stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Total score of the Elf's guide was: {Part2(RPSPairs)}");
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
        }

        static int Part1(List<RPSPair> RPSPairs)
        {
            int totalScore = 0;

            foreach (var pair in RPSPairs)
            {
                // P2 wins (nous)
                if ((pair.P1 - ABCAdjust + 1) % 3 == (pair.P2 - XYZAdjust))
                    totalScore += (pair.P2 - XYZAdjust) + 6;
                // draw
                else if ((pair.P1 - ABCAdjust) == (pair.P2 - XYZAdjust))
                    totalScore += (pair.P2 - XYZAdjust) + 3;
                // P1 wins
                else
                    totalScore += (pair.P2 - XYZAdjust);
            }

            totalScore += RPSPairs.Count;

            return totalScore;
        }

        static int Part2(List<RPSPair> rpsPairs)
        {
            int totalScore = 0;

            foreach (var pair in rpsPairs)
            {
                int value = 0;
                if (pair.P2 == 'Z')
                    totalScore += 6 + (pair.P1 - ABCAdjust + 1) % 3; // Win (6 + jet choisi)
                else if (pair.P2 == 'Y')
                    totalScore += 3 + (pair.P1 - ABCAdjust); // Draw (3 + jet chosi)
                else
                    totalScore += (pair.P1 - ABCAdjust + 2) % 3; // Lose (0 + jet choisi)

            }

            totalScore += rpsPairs.Count;

            return totalScore;
        }
    }
}