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

            builder.Remove(builder.Length - 1, 1);
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

        public static async Task<Dictionary<int, Stack<char>>> ComputeDay5(Task<string> rawInput)
        {
            var data = await rawInput;
            string[] lines = data.Split('\n');
            int index = 0;
            List<string> containers= new List<string>();
            do
            {

            } while (!int.TryParse(lines[index], out _));
            Dictionary<int, Stack<char>> stacks = new();

            return stacks;
        }
    }
}
