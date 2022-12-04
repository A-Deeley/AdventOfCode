using System.Diagnostics;

namespace AdventDisplayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            AdventOfCode1.Program.Main(args);
            AdventOfCode2.Program.Main(args);
            AdventOfCode3.Program.Main(args);
            AdventOfCode4.Program.Main(args);
            stopwatch.Stop();

            Console.WriteLine($"\n\nTOTAL TIME: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedTicks} ticks).");

            Console.ReadKey();
        }
    }
}