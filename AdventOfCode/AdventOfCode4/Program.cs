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
            Console.WriteLine($"Sum of sections containing the other section was: {Part1(sectionPairs)}");
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
            Console.WriteLine("======Part 2======");
            stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Sum of overlapping sections was: {Part2(sectionPairs)}");
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
        }
		
		static string Part1(List<string> sectionPairs)
		{
			int totalOverlappingAssignments = 0;
			foreach (var sectionPair in sectionPairs)
			{
				bool assignmentFitsInOther = false;
				var splitPair = sectionPair.Split(',');
				var leftPair = new SectionPair(splitPair[0]);
				var rightPair = new SectionPair(splitPair[1]);

				if (leftPair.Length() < rightPair.Length())
					assignmentFitsInOther = leftPair.Start >= rightPair.Start && (leftPair.Start + leftPair.Length()) <= rightPair.End;
				else if (leftPair.Length() > rightPair.Length())
					assignmentFitsInOther = rightPair.Start >= leftPair.Start && (rightPair.Start + rightPair.Length()) <= leftPair.End;
				else
					assignmentFitsInOther = leftPair.Equals(rightPair);

				if (assignmentFitsInOther)
					totalOverlappingAssignments++;
			}

			return totalOverlappingAssignments.ToString();
		}

		static string Part2(List<string> sectionPairs)
		{
			int totalOverlappingAssignments = 0;

			foreach (var sectionPair in sectionPairs)
			{
                bool assignmentFitsInOther = false;
                var splitPair = sectionPair.Split(',');
                var leftPair = new SectionPair(splitPair[0]);
                var rightPair = new SectionPair(splitPair[1]);

				if (leftPair.Overlaps(rightPair))
					totalOverlappingAssignments++;
            }

			return totalOverlappingAssignments.ToString();
		}
    }

	struct SectionPair
	{
		public SectionPair(string section)
		{
			var numbers = section.Split('-');
			Start = int.Parse(numbers[0]);
			End = int.Parse(numbers[1]);
		}

		public int Start { get; set; }
		public int End { get; set; }

		public int Length() => End - Start;

		public override bool Equals([NotNullWhen(true)] object? obj)
		{
			if (obj is not SectionPair otherPair)
				return false;

			return Start == otherPair.Start && End == otherPair.End;
		}

		public bool Overlaps(SectionPair otherPair) => !(otherPair.Start > End || Start > otherPair.End);
	}


}


