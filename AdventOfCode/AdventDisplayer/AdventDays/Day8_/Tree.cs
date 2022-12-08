namespace AdventDisplayer.AdventDays.Day8_
{
    internal class Tree
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int ScenicScore { get; set; }

        public Dictionary<(int, int), Tree?> RelativeTrees { get; set; }

        public Tree(int x, int y, int height)
        {
            X = x;
            Y = y;
            Height = height;

            RelativeTrees = new()
            {
                { (-1, 0), null },
                { (0, -1), null },
                { (1, 0), null },
                { (0, 1), null }
            };
        }

        public Tree? this[int x, int y]
        {
            get => RelativeTrees[(x, y)];
            set => RelativeTrees[(x, y)] = value;
        }

        public bool IsVisible(int x, int y, int sourceTreeHeight)
        {
            Tree relativeTree = RelativeTrees[(x, y)];
            if (relativeTree is null)
                return true;

            if (relativeTree.Height < sourceTreeHeight)
                return relativeTree.IsVisible(x, y, sourceTreeHeight);

            return false;
        }

        public int IsVisibleDistance(int x, int y, int sourceTreeHeight, int currentDistance = 0)
        {
            Tree relativeTree = RelativeTrees[(x, y)];
            if (relativeTree is null)
                return currentDistance;

            if (relativeTree.Height < sourceTreeHeight)
                return relativeTree.IsVisibleDistance(x, y, sourceTreeHeight, ++currentDistance);

            return ++currentDistance;
        }

        public void ComputeScenicScore()
        {
            List<int> scores = new(4);

            scores.Add(IsVisibleDistance(-1, 0, Height));
            scores.Add(IsVisibleDistance(1, 0, Height));
            scores.Add(IsVisibleDistance(0, -1, Height));
            scores.Add(IsVisibleDistance(0, 1, Height));

            ScenicScore = scores.Aggregate((current, next) => current * next);
        }
    }
}
