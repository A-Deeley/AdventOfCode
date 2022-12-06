using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDisplayer.AdventDays
{
    internal class Day5 : Day<Dictionary<int, Stack<char>>>
    {
        Task _moveTask;
        List<(int qty, int source, int dest)> _moves;
        public Day5(Task<Dictionary<int, Stack<char>>> input, Task<List<(int, int, int)>> moves)
            : base(input) 
        {
            _moveTask = moves;
            Part1Description = "Crates on top of each stack (CrateMover 9000)";
            Part2Description = "Crates on top of each stack (CrateMover 9001)";
        }

        public override async Task Start()
        {
            ExecTimer.Start();
            _moves = await (Task<List<(int, int, int)>>)_moveTask;
            Dictionary<int, Stack<char>> crateStacksInitialSim = CopyCrateConfiguration(await _input);

            int movesRemaining = _moves.Count;
            foreach (var move in _moves)
            {
                movesRemaining--;
                for (int qtyCrates = 0; qtyCrates < move.qty; qtyCrates++)
                {
                    char crate = crateStacksInitialSim[move.source].Pop();
                    crateStacksInitialSim[move.dest].Push(crate);
                }
            }

            StringBuilder builder = new();
            foreach (var crateStack in crateStacksInitialSim)
                builder.Append($"[{crateStack.Value.Pop()}] ");

            Part1Answer = builder.ToString();
            Dictionary<int, Stack<char>> crateStacksRealSim = CopyCrateConfiguration(await _input);

            Stack<char> craneInventory = new();
            foreach (var move in _moves)
            {
                for (int qtyCrates = 0; qtyCrates < move.qty; qtyCrates++)
                    craneInventory.Push(crateStacksRealSim[move.source].Pop());

                while (craneInventory.Count > 0)
                    crateStacksRealSim[move.dest].Push(craneInventory.Pop());
            }

            builder.Clear();
            foreach (var crateStack in crateStacksRealSim)
                builder.Append($"[{crateStack.Value.Pop()}] ");

            Part2Answer = builder.ToString();
            ExecTimer.Stop();
        }

        private Dictionary<int, Stack<char>> CopyCrateConfiguration(Dictionary<int, Stack<char>> dictionary)
        {
            Dictionary<int, Stack<char>> copy = new();

            foreach (var kvpair in dictionary)
                copy.Add(kvpair.Key, new Stack<char>(kvpair.Value.Reverse()));

            return copy;
        }
    }
}
