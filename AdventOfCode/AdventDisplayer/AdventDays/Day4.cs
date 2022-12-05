using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer.AdventDays
{
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

    internal class Day4 : Day<string>
    {
        public Day4(Task<string> input)
            : base(input)
        {
            Part1Description = "Sum of sections containing the other section";
            Part2Description = "Sum of overlapping sections";
        }

        public override async Task Start()
        {
            ExecTimer.Start();
            var data = await _input;
            List<string> sectionPairs = new(data.Split('\n'));

            int totalOverlappingAssignments = 0;
            foreach (var sectionPair in sectionPairs)
            {
                bool assignmentFitsInOther = false;
                var splitPair = sectionPair.Split(',');
                var leftPair = new SectionPair(splitPair[0]);
                var rightPair = new SectionPair(splitPair[1]);

                if (leftPair.Length() < rightPair.Length())
                    assignmentFitsInOther = leftPair.Start >= rightPair.Start && leftPair.Start + leftPair.Length() <= rightPair.End;
                else if (leftPair.Length() > rightPair.Length())
                    assignmentFitsInOther = rightPair.Start >= leftPair.Start && rightPair.Start + rightPair.Length() <= leftPair.End;
                else
                    assignmentFitsInOther = leftPair.Equals(rightPair);

                if (assignmentFitsInOther)
                    totalOverlappingAssignments++;
            }

            Part1Answer = totalOverlappingAssignments;
            totalOverlappingAssignments = 0;

            foreach (var sectionPair in sectionPairs)
            {
                bool assignmentFitsInOther = false;
                var splitPair = sectionPair.Split(',');
                var leftPair = new SectionPair(splitPair[0]);
                var rightPair = new SectionPair(splitPair[1]);

                if (leftPair.Overlaps(rightPair))
                    totalOverlappingAssignments++;
            }

            Part2Answer = totalOverlappingAssignments;
        }
    }
}
