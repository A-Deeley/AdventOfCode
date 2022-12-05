using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer.AdventDays
{
    internal class Day3 : Day<string>
    {
        const int LowercaseAdjust = 'a' - 1;
        const int UppercaseAdjust = 'A' - 27;

        public Day3(Task<string> input)
            : base(input)
        {
            Part1Description = "Sum of priorities of items in each rucksack";
            Part2Description = "Sum of priorities of badge IDs";
        }

        public override async Task Start()
        {
            ExecTimer.Start();
            var data = await _input;
            List<string> backpacks = new(data.Split('\n'));
            int backpackIndex = 0;
            int prioritySum = 0;

            do
            {
                List<int[]> groupBps = new()
                {
                    new int[52],
                    new int[52],
                    new int[52]
                };


                for (int i = 0; i < 3; i++)
                {
                    var T = i;
                    foreach (char letter in backpacks[backpackIndex + i])
                    {
                        int letterIndex = letter is >= 'a' and <= 'z' ? letter - LowercaseAdjust : letter - UppercaseAdjust;
                        groupBps[i][letterIndex - 1]++;
                    }
                }



                int[] result = new int[52];
                for (int i = 0; i < groupBps[0].Count(); i++)
                {
                    if (groupBps[0][i] > 0 && groupBps[1][i] > 0 && groupBps[2][i] > 0)
                        result[i] = 1;
                }
                List<int> resultAsList = new(result);

                if (!resultAsList.Contains(1))
                    throw new ArgumentException();

                prioritySum += resultAsList.IndexOf(1) + 1;

                backpackIndex += 3;
            } while (backpackIndex < backpacks.Count);

            Part1Answer = prioritySum;
            prioritySum = 0;

            foreach (string backpackrow in backpacks)
            {
                // Get the compartments
                int compartmentSize = backpackrow.Length / 2;
                string left = backpackrow.Substring(0, compartmentSize);
                string right = backpackrow.Substring(compartmentSize);

                foreach (char letter in left)
                {
                    if (right.Contains(letter))
                    {
                        if (letter is >= 'a' and <= 'z')
                            prioritySum += letter - LowercaseAdjust;
                        else
                            prioritySum += letter - UppercaseAdjust;

                        break;
                    }
                }
            }

            Part2Answer = prioritySum;

            ExecTimer.Stop();
        }
    }
}
