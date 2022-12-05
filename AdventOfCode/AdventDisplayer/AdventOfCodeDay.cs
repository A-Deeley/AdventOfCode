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
        protected Stopwatch _execTimer;

        public virtual object Part1Answer { get; protected set; }
        public virtual object Part2Answer { get; protected set; }
        public string Part1Description { get; set; }
        public string Part2Description { get; set; }

        public AdventOfCodeDay()
        {
            _execTimer = new();
        }

        public long GetTimeMilliseconds() => _execTimer.ElapsedMilliseconds;
        public long GetTimeTicks() => _execTimer.ElapsedTicks;
        public abstract Task Start();
    }
}
