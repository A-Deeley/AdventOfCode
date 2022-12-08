namespace AdventDisplayer.AdventDays.Day7_
{
    internal class Day7 : Day<string>
    {
        struct TerminalCommand
        {
            public string Command { get; set; }
            public string[]? Args { get; set; }
            public string[]? Output { get; set; }

            public TerminalCommand(string commandName, string[] args, params string[] output)
            {
                Command = commandName;
                Args = args;
                Output = output;
            }
        }

        public Day7(Task<string> input) : base(input)
        {
            Part1Description = "Sum of directories containing data of size at most 100,000";
        }

        public override async Task Start()
        {
            ExecTimer.Start();

            var data = await _input;
            List<string> terminal = new(data.Split('\n'));

            List<TerminalCommand> commands = new();
            for (int i = 0; i < terminal.Count; i++)
            {
                if (!terminal[i].StartsWith("$"))
                {
                    continue;
                }
                string[] commandLine = terminal[i].Split(' ');
                string commandName = commandLine[1];

                if (commandName == "cd")
                {
                    TerminalCommand cdCommand = new(commandName, commandLine[2..]);
                    commands.Add(cdCommand);
                    continue;
                }

                if (commandName == "ls")
                {
                    List<string> outputs = new();
                    int outputLine = 1;
                    while (i + outputLine < terminal.Count && !terminal[i + outputLine].StartsWith("$"))
                    {
                        outputs.Add(terminal[i + outputLine]);
                        outputLine++;
                    }
                    TerminalCommand lsCommand = new(commandName, Array.Empty<string>(), outputs.ToArray());
                    commands.Add(lsCommand);
                    continue;
                }
            }

            Folder root = new(null, "/");
            IFileSystemParent currentFolder = root;
            commands.RemoveAt(0);

            foreach (var command in commands)
            {
                if (command.Command == "cd")
                {
                    currentFolder = currentFolder.Navigate(command.Args[0]);
                    continue;
                }

                if (command.Command == "ls")
                {
                    var folders = command.Output.Where(output => output.StartsWith("dir"));
                    var files = command.Output.Where(output => !output.StartsWith("dir"));

                    currentFolder.AddFolders(folders);
                    currentFolder.AddFiles(files);
                }
            }

            Part1Answer = root.GetChildrenOfSize(100000).Sum(children => children.GetSizeOfContents());

            long totalSpace = 70000000;
            long spaceAvailable = totalSpace - root.GetSizeOfContents();
            long spaceNeeded = 30000000 - spaceAvailable;

            Part2Description = $"Size of smallest folder to delete to free {spaceNeeded} space";
            Part2Answer = root.GetChildrenOfSize(totalSpace).OrderBy(child => child.GetSizeOfContents()).First(child => child.GetSizeOfContents() >= spaceNeeded).GetSizeOfContents();

            ExecTimer.Stop();
        }
    }
}