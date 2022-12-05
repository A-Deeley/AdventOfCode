using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer
{
    internal sealed class Day1 : Day<string>
    {
        public Day1(Task<string> input)
            : base(input) 
        {
            Part1Description = "Calories carried by the elf carrying the most calories";
            Part2Description = "The sum of calories carried by the top 3 elves";
        }

        public override async Task Start()
        {
            ExecTimer.Start();
            var data = await _input;
            List<string> elfCalories = new(data.Split('\n'));

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

            Elf[] elvesOrderedByCalories = elves.OrderByDescending(elf => elf.TotalCalories).ToArray();
            Part1Answer = elvesOrderedByCalories[0].TotalCalories;
            Part2Answer = elvesOrderedByCalories[0..3].Sum(elf => elf.TotalCalories);

            ExecTimer.Stop();
        }

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
    }
}
