using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer.AdventDays.Day7_
{
    internal interface IFileSystemParent
    {
        public List<IFileSystemObject> Children { get; set; }
        public IFileSystemParent Navigate(string childName);
        public void AddFiles(IEnumerable<string> fileLines);
        public void AddFolders(IEnumerable<string> folderLines);
        public long GetSizeOfContents();
        public IEnumerable<IFileSystemParent> GetChildrenOfSize(long size);
    }
}
