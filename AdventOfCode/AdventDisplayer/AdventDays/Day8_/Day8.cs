namespace AdventDisplayer.AdventDays.Day8_
{
    internal class Day8 : Day<int[][]>
    {
        public Day8(Task<int[][]> input) : base(input)
        {
            Part1Description = "Quantity of trees visible from outside the grid";
            Part2Description = "Highest scenic score possible";
        }

        public override async Task Start()
        {
            ExecTimer.Start();

            var data = await _input;
            var trees = new Forest(data);
            int totalVisibleTrees = 0;

            for (int x = 0; x < trees.Trees.GetLength(0); x++)
            {
                for (int y = 0; y < trees.Trees.GetLength(1); y++)
                {
                    if (trees.Trees[x, y].IsVisible(-1, 0, trees.Trees[x, y].Height))
                    {
                        totalVisibleTrees++;
                        continue;
                    }
  
                    if (trees.Trees[x, y].IsVisible(1, 0, trees.Trees[x, y].Height))
                    {
                        totalVisibleTrees++;
                        continue;
                    }

                    if (trees.Trees[x, y].IsVisible(0, 1, trees.Trees[x, y].Height))
                    {
                        totalVisibleTrees++;
                        continue;
                    }

                    if (trees.Trees[x, y].IsVisible(0, -1, trees.Trees[x, y].Height))
                    {
                        totalVisibleTrees++;
                        continue;
                    }
                }
            }



            Part1Answer = totalVisibleTrees;
            Part2Answer = trees.GetMostScenicScore();


            ExecTimer.Stop();
        }
    }
}
