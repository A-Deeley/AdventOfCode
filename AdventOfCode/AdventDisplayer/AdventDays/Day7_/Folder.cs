using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer.AdventDays.Day7_
{
    internal class Folder : IFileSystemObject, IFileSystemParent
    {
        public IFileSystemParent? Parent { get;  set; }
        public string Name { get; set; }
        public List<IFileSystemObject> Children { get; set; }

        long? _cachedSizeOfContent;

        public Folder(IFileSystemParent? parent, string name)
        {
            Parent = parent;
            Name = name;
            Children = new();
        }

        public IFileSystemParent Navigate(string childName)
        {
            if (childName == "..")
                return Parent;

            var folder = Children.OfType<Folder>().FirstOrDefault(folder => folder.Name == childName);
            if (folder is null)
            {
                folder = new(this, childName);
                Children.Add(folder);
            }

            return folder;
        }

        public void AddFiles(IEnumerable<string> fileLines)
        {
            foreach (var file in fileLines)
                Children.Add(new File(this, file));
        }

        public void AddFolders(IEnumerable<string> folderLines)
        {
            foreach (var folder in folderLines)
            {
                string folderName = folder.Split(' ')[1];
                Children.Add(new Folder(this, folderName));
            }
        }

        public long GetSizeOfContents()
        {
            if (_cachedSizeOfContent is not null)
                return (long)_cachedSizeOfContent;

            long totalSize = 0;
            foreach (var folder in Children.OfType<Folder>())
                totalSize += folder.GetSizeOfContents();

            foreach (var file in Children.OfType<File>())
                totalSize += file.Size;

            _cachedSizeOfContent = totalSize;
            return totalSize;
        }

        public IEnumerable<IFileSystemParent> GetChildrenOfSize(long size)
        {
            List<IFileSystemParent> children = new();

            children.AddRange(Children.OfType<Folder>().Where(folder => folder.GetSizeOfContents() <= size));
            
            foreach (var folder in Children.OfType<Folder>())
                children.AddRange(folder.GetChildrenOfSize(size));


            return children;
        }
    }
}
