using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer
{
    internal class AdventOfCodeList : List<AdventOfCodeDay>
    {
        List<Task> dayTasks;

        public AdventOfCodeList()
            :base()
        {
            dayTasks = new();
        }

        public AdventOfCodeList(int capacity)
            : base(capacity)
        {
            dayTasks = new(capacity);
        }


        public new void Add(AdventOfCodeDay day)
        {
            base.Add(day);
            dayTasks.Add(day.Start());
        }

        public Task ComputeAll() => Task.WhenAll(dayTasks);
    }
}
