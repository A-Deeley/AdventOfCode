using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventHelper
{
    public static class PuzzleInputManager
    {
        public static async Task<List<string>> LoadPuzzleText(string path)
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
