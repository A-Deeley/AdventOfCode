using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer.AdventDays.Day7Classes
{
    internal class File : IFileSystemObject
    {
        public IFileSystemParent Parent { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }

        public File (Folder parent, string terminalLine)
        {
            Parent = parent;
            string[] parsedLine = terminalLine.Split(' ');
            Size = int.Parse(parsedLine[0]);
            Name = parsedLine[1];
        }
    }
}
