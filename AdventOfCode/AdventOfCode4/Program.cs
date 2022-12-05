using AdventHelper;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode4
{
    public class Program
    {
        public static void Main(string[] args)
        {
			List<string> sectionPairs = PuzzleInputManager.LoadPuzzleText("Inputs/PuzzleInput4.txt").Result;

            Console.WriteLine("\n\nDay 4:");
            Console.WriteLine("======Part 1======");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine($" was: {Part1(sectionPairs)}");
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
            Console.WriteLine("======Part 2======");
            stopwatch = Stopwatch.StartNew();
            Console.WriteLine($" was: {Part2(sectionPairs)}");
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
        }
		
		static string Part1(List<string> sectionPairs)
		{
			

			return totalOverlappingAssignments.ToString();
		}

		static string Part2(List<string> sectionPairs)
		{
			int 

			return totalOverlappingAssignments.ToString();
		}
    }

	


}


