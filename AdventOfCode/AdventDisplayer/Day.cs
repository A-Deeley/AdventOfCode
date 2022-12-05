using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer
{
    internal abstract class Day<TTaskResult> : AdventOfCodeDay
    {
        protected Task<TTaskResult> _input;

        public Day(Task<TTaskResult> input)
            :base()
        {
            _input = input;
        }
    }
}
