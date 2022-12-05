using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventHelper
{
    public static class PuzzleInputManager
    {
        static async Task<string> LoadPuzzleTextAsync(string path)
        {
            StringBuilder builder = new();
            using StreamReader reader = new StreamReader($"Inputs/{path}");
            
            while (!reader.EndOfStream)
                builder.Append($"{await reader.ReadLineAsync()}\n" ?? "\n");


            return builder.ToString();
        }

        public static List<Task<string>> GetAllPuzzlesAsync(int quantity)
        {
            List<Task<string>> tasks = new(quantity);
            for (int i = 0; i < quantity; i++)
            {
                tasks.Add(LoadPuzzleTextAsync($"Day{i + 1}.txt"));
            }

            return tasks;
        }
    }
}
