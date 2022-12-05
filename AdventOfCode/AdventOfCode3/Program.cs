using AdventHelper;
using System.Diagnostics;

namespace AdventOfCode3
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            List<string> backpacks = PuzzleInputManager.LoadPuzzleText("Inputs/PuzzleInput3.txt").Result;
            Console.WriteLine("\n\nDay 3:");
            Console.WriteLine("======Part 1======");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Priority sum was: {Part1(backpacks)}");
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
            Console.WriteLine("\n======Part 2======");
            stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Priority sum was: {Part2(backpacks)}");
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
        }

        static string Part2(List<string> backpacks)
        {
            


            return prioritySum.ToString();
        }

        static string Part1(List<string> backpacks)
        {
            int prioritySum = 0;


            


            return prioritySum.ToString();
        }
    }
}