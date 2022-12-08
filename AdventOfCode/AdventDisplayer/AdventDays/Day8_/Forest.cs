namespace AdventDisplayer.AdventDays.Day8_
{
    internal class Forest
    {
        public Tree[,] Trees { get; set; }

        public Forest(int[][] grid)
        {
            Trees = new Tree[grid.GetLength(0), grid.GetLength(0)];

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid[x].Length; y++)
                {
                    Trees[x, y] = new(x, y, grid[x][y]);
                }
            }

            for (int x = 0; x < Trees.GetLength(0); x++)
            {
                for (int y = 0; y < Trees.GetLength(1); y++)
                {
                    try { Trees[x, y][-1, 0] = Trees[x - 1, y]; } catch { Trees[x, y][-1, 0] = null; }
                    try { Trees[x, y][1, 0] = Trees[x + 1, y]; } catch { Trees[x, y][1, 0] = null; }
                    try { Trees[x, y][0, 1] = Trees[x, y + 1]; } catch { Trees[x, y][0, 1] = null; }
                    try { Trees[x, y][0, -1] = Trees[x, y - 1]; } catch { Trees[x, y][0, -1] = null; }
                }
            }


        }

        public int GetMostScenicScore()
        {
            List<Tree> sortedTrees = new(Trees.Length);
            foreach (var tree in Trees)
            {
                tree.ComputeScenicScore();
                sortedTrees.Add(tree);
            }

            return sortedTrees.OrderByDescending(tree => tree.ScenicScore).First().ScenicScore;
        }
    }
}
