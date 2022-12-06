using AdventDisplayer.AdventDays;
using AdventHelper;
using System;
using System.Diagnostics;

namespace AdventDisplayer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            long totalExecutionTime = 0;
            int daysFromStart = DateTime.Today.Day;
            AdventOfCodeList days = new(daysFromStart);

            // Load puzzle inputs
            Stopwatch watch = Stopwatch.StartNew();
            List<Task<string>> puzzleInputs = PuzzleInputManager.GetAllPuzzlesAsync(daysFromStart);
            watch.Stop();
            long totalFileOpTime = watch.ElapsedMilliseconds;
            Stopwatch day5OverrideTime = Stopwatch.StartNew();
            var day5Crates = PuzzleInputManager.Day5_GetCrates(puzzleInputs[4]);
            var day5Moves = PuzzleInputManager.Day5_GetMoves(puzzleInputs[4]);
            day5OverrideTime.Stop();

            days.Add(new Day1(puzzleInputs[0]));
            days.Add(new Day2(puzzleInputs[1]));
            days.Add(new Day3(puzzleInputs[2]));
            days.Add(new Day4(puzzleInputs[3]));
            var day5Special = new Day5(day5Crates, day5Moves);
            day5Special.ExecTimer = day5OverrideTime;
            days.Add(day5Special);
            days.Add(new Day6(puzzleInputs[5]));


            await days.ComputeAll();

            for (int dayNo = 1; dayNo <= daysFromStart; dayNo++)
            {
                int currentDay = dayNo - 1;
                string p1Desc = $"1: {days[currentDay].Part1Description}";
                string p1Ans = days[currentDay].Part1Answer.ToString();
                string p2Desc = $"2: {days[currentDay].Part2Description}";
                string p2Ans = days[currentDay].Part2Answer.ToString();
                if (p1Ans.Length < p2Ans.Length)
                    p1Ans = p1Ans.PadLeft(p2Ans.Length);
                else
                    p2Ans = p2Ans.PadLeft(p1Ans.Length);
                int p1Length = p1Desc.Length + p1Ans.Length;
                int p2Length = p2Desc.Length + p2Ans.Length;
                string execTimeText = $"Execution time: ";
                string execTimeMs = $"{days[currentDay].ExecTimer.Elapsed.TotalSeconds}s ({days[currentDay].ExecTimer.ElapsedMilliseconds}ms)";
                string execTimeTicks = $" ({days[currentDay].ExecTimer.ElapsedTicks} ticks)";
                int biggestLength = Math.Max(p1Length, p2Length) + Math.Min(p1Ans.Length, p2Ans.Length);
                bool isP1Bigger = p1Length + p1Ans.Length > p2Length + p2Ans.Length;
                string title = $"Day {(dayNo < 10 ? $" {dayNo}" : dayNo)}";
                title = title.PadLeft(biggestLength / 2, '-');
                title = title.PadRight((biggestLength / 2 % 2 == 1 ? biggestLength / 2 : biggestLength / 2 + 1) + title.Length, '-');
                Console.WriteLine(title);
                if (isP1Bigger)
                {
                    Console.Write("| ");
                    ChristmasConsole.Write($"{p1Desc}: ", ConsoleColor.Green);
                    ChristmasConsole.Write(p1Ans, ConsoleColor.Yellow);
                    Console.WriteLine(" |");

                    Console.Write("| ");
                    ChristmasConsole.Write($"{p2Desc.PadRight(p1Desc.Length)}: ", ConsoleColor.Red);
                    ChristmasConsole.Write(p2Ans, ConsoleColor.Yellow);
                    Console.WriteLine(" |");
                }
                else
                {
                    Console.Write("| ");
                    ChristmasConsole.Write($"{p1Desc.PadRight(p2Desc.Length - p1Desc.Length)}: ", ConsoleColor.Green);
                    ChristmasConsole.Write(p1Ans, ConsoleColor.Yellow);
                    Console.WriteLine(" |");

                    Console.Write("| ");
                    ChristmasConsole.Write(p2Desc, ConsoleColor.Red);
                    ChristmasConsole.Write(p2Ans, ConsoleColor.Yellow);
                    Console.WriteLine(" |");
                }
                Console.Write("| ");
                int execLength = execTimeMs.Length + execTimeText.Length + execTimeTicks.Length;
                ChristmasConsole.Write(execTimeText, ConsoleColor.Green);
                ChristmasConsole.Write(execTimeMs, ConsoleColor.Red);
                ChristmasConsole.Write(execTimeTicks, ConsoleColor.Green);
                ChristmasConsole.Write(".".PadRight((biggestLength - execLength) > (0 + 4) ? biggestLength - execLength - 4 : 0), ConsoleColor.Red);
                Console.WriteLine(" |");
                Console.WriteLine("".PadLeft(biggestLength, '-'));
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}