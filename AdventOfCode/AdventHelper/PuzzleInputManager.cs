using System.Text;

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

        public static async Task<Dictionary<int, Stack<char>>> Day5_GetCrates(Task<string> rawInput)
        {
            var data = await rawInput;
            string[] lines = data.Split('\n');
            int stackColumnNumber = 0;
            Dictionary<int, Stack<char>> stacks = new();

            // The first crate has no space in front (text file), but all the others have a space
            // |[Q] [E]...
            // so we need to add 1 to the crateOffset after the first iteration.
            int crateAdjust = 0;
            do
            {
                List<char> crates = new();
                int stackRowNumber = 0;
                char stackItem = ' ';
                int crateOffset = (stackColumnNumber * 3) + crateAdjust;
                do
                {
                    // Get the letter of the stack item inside the bracket (ex: [Q], get the 'Q').
                    var test = lines[stackRowNumber].Substring(crateOffset, 3);
                    stackItem = test[1];

                    if (!char.IsWhiteSpace(stackItem))
                        crates.Add(stackItem);

                    stackRowNumber++;
                } while (!char.IsDigit(stackItem));
                crates.RemoveAt(crates.Count - 1);
                crates.Reverse();
                stacks.Add(stackColumnNumber + 1, new(crates));
                stackColumnNumber++;
                crateAdjust++;
            } while (stackColumnNumber < 9);
            return stacks;
        }

        public static async Task<List<(int, int, int)>> Day5_GetMoves(Task<string> rawInput)
        {
            var data = await rawInput;
            string[] lines = data.Split('\n');

            int movesStartIndex = 0;
            while (!string.IsNullOrWhiteSpace(lines[movesStartIndex]))
                movesStartIndex++;

            List<(int, int, int)> moves = new(lines.Length - movesStartIndex);
            for (int i = movesStartIndex + 1; i < lines.Length; i++)
            {
                var textAsArray = lines[i].Split(' ');
                int instructionNumberCounter = 0;
                int[] instructionNumbers = new int[3];
                int word = 0;
                while (instructionNumberCounter < 3)
                {
                    if (int.TryParse(textAsArray[word], out instructionNumbers[instructionNumberCounter]))
                        instructionNumberCounter++;
                    word++;
                }
                moves.Add((instructionNumbers[0], instructionNumbers[1], instructionNumbers[2]));
            }

            return moves;
        }
    }
}
