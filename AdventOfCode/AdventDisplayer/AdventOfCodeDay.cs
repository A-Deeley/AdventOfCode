using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer
{
    internal abstract class AdventOfCodeDay
    {
        public Stopwatch ExecTimer { get; set; }

        public virtual object Part1Answer { get; protected set; }
        public virtual object Part2Answer { get; protected set; }
        public string Part1Description { get; set; }
        public string Part2Description { get; set; }

        public AdventOfCodeDay()
        {
            ExecTimer = new();
        }
        public abstract Task Start();
    }
}
