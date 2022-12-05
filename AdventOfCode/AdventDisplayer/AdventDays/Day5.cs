using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer.AdventDays
{
    internal class Day5 : Day<Dictionary<int, Stack<char>>>
    {
        Dictionary<int, Stack<char>> _stacks;

        public Day5(Dictionary<int, Stack<char>> stacks)
            : base(null)
        {
            _stacks = stacks;
        }

        public override async Task Start()
        {
            ExecTimer.Start();



            ExecTimer.Stop();
        }
    }
}
