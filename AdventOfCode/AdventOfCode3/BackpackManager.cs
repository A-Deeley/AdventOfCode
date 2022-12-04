using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode3
{
    internal static class BackpackManager
    {
        internal static async Task<List<string>> LoadBackpack(string path)
        {
            List<string> backpacks = new();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                    backpacks.Add(await reader.ReadLineAsync() ?? "");
            }

            return backpacks;
        }
    }
}
