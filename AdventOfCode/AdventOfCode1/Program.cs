using AdventHelper;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AdventOfCode1
{
    public class Program
    {
        struct Elf
        {
            public Elf(IEnumerable<string> calories)
            {
                TotalCalories = 0;
                foreach (var calorie in calories)
                    TotalCalories += int.Parse(calorie);
            }
            
            public int TotalCalories { get; set; }
            public override string ToString() => TotalCalories.ToString();
        }

        public static async Task Main(string[] args)
        {
            List<string> elfCalories = await PuzzleInputManager.LoadPuzzleText("Inputs/PuzzleInput1.txt");
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            var topThree = Part1and2(elfCalories);
            stopwatch.Stop();

            Console.WriteLine("\n\nDay 1:");
            Console.WriteLine("======Part 1======");
            Console.WriteLine($"Elf carrying the most calories: {topThree[0]}");
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
            Console.WriteLine("======Part 2======");
            //stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Sum of top three elf calories: {topThree.Sum(elf => elf.TotalCalories)}");
            //stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");
        }

        static Elf[] Part1and2(List<string> elfCalories)
        {
            List<Elf> elves = new();

            List<string> singleElfCalories = new();
            foreach (var elfCalorie in elfCalories)
            {
                if (string.IsNullOrEmpty(elfCalorie))
                {
                    elves.Add(new(singleElfCalories));
                    singleElfCalories = new();
                }
                else
                    singleElfCalories.Add(elfCalorie);

            }

            return elves.OrderByDescending(elf => elf.TotalCalories).ToArray()[0..3];
        }
    }
}