using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer.AdventDays.Day7_
{
    internal interface IFileSystemObject
    {
        public IFileSystemParent Parent { get; set; }
        public string Name { get; set; }

        public string ToString() => Name;
    }
}
